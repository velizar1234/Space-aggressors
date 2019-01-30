using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using Anglia.CGTech.CKit.Helper.Library;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Anglia.Editor.CGTech.Kit
{
    /// <summary>
    /// Custom Inspector and Gizmo for the Construction Kit components.
    /// </summary>
    public class KitComponentGizmo
    {
        
        
        #region Custom Gizmo
        /// <summary>
        /// Gizmo drawing function applied to all KitComponents
        /// </summary>
        /// <param name="currentKitComponent">Target Kit Component</param>
        /// <param name="gizmoType">Gizmo Type Requested </param>
        [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.InSelectionHierarchy | GizmoType.NotInSelectionHierarchy | GizmoType.Pickable | GizmoType.Active)]
        private static void OnSceneGUI(KitComponent currentKitComponent, GizmoType gizmoType)
        {
            bool isDistant = false;
            int fontSize = KitSettings.DefaultFontSize;
            Camera[] cameras = SceneView.GetAllSceneCameras();
            for (int i = 0; i < cameras.Length; i++)
            {
                float camDistance = (cameras[i].transform.position - currentKitComponent.transform.position).magnitude;
                //fontSize = Mathf.RoundToInt(KitSettings.DefaultFontSize / (camDistance / KitSettings.ViewDistance));
                fontSize = Mathf.RoundToInt(Mathf.Lerp(KitSettings.MinimumFontSize, KitSettings.MaximumFontSize, 1 - (camDistance/KitSettings.ViewDistance)));
                if (camDistance > KitSettings.ViewDistance)
                {
                    isDistant = true;
                }
            }
            bool showElement = true;
            bool overrideGizmo = SpecialisedGizmos.Draw(currentKitComponent,isDistant,fontSize);
            if (currentKitComponent.name == "XX")
                Debug.LogFormat(" Gizmo for {0}, mode {1}", currentKitComponent.name, Convert.ToString((int)gizmoType, 2));

            bool showGizmo = false;
            showGizmo = (gizmoType == GizmoType.Selected);
            showGizmo |= (gizmoType == GizmoType.InSelectionHierarchy);
            showGizmo |= (currentKitComponent.hideGizmos == false);
            showGizmo |= currentKitComponent.currentlySelected;

            if (showGizmo)
            {
                currentKitComponent.SetGizmoSelected(true);
                GizmoHelper.SetUnityGizmo(currentKitComponent.gameObject, currentKitComponent.GetPartType());
            }
            else
            {
                showElement = false;
                GizmoHelper.SetUnityGizmo(currentKitComponent.gameObject, GizmoHelper.PartType.Undefined);
            }

            int nodeRowCount = CountGUINodes(currentKitComponent);

            //Only show one component per game object.
            int kitComponentsCount = currentKitComponent.gameObject.GetComponents<KitComponent>().Length;
            if (kitComponentsCount > 1)
            {
                if (currentKitComponent != currentKitComponent.gameObject.GetComponent<KitComponent>())
                    showElement = false;
            }

            if (showElement && !overrideGizmo)
            {
                Vector3[] corners = new Vector3[4];
                Vector3 size = new Vector3(KitFieldInfo.NODE_WIDTH * 2f, KitFieldInfo.NODE_HEIGHT * ((float)nodeRowCount + 2f), -0f);
                Vector3 centre = currentKitComponent.transform.position - size.y / 2f * Vector3.up;
                currentKitComponent.windowDisplayRect = new Rect(centre, size);
                corners[0] = centre - size / 2;
                corners[1] = centre - size / 2 + Vector3.up * size.y;
                corners[2] = centre + size / 2;
                corners[3] = centre + size / 2 + Vector3.down * size.y;

                Gizmos.color = Color.black;
                if (currentKitComponent is ActiveKitComponent)
                {
                    Gizmos.color = GizmoHelper.ActiveBackground;
                }

                //Handles.DrawWireCube(centre, size);
                //or
                Handles.DrawSolidRectangleWithOutline(corners, Gizmos.color, GizmoHelper.Lighten(Gizmos.color));

                List<KitFieldInfo> lhf = null, rhf = null;
                BuildSideArrays(out lhf,out rhf, currentKitComponent);
                DrawGUINodes(lhf, rhf, currentKitComponent, isDistant, fontSize);
            }

            if (showElement)
            {
                FieldInfo[] fields = currentKitComponent.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                for (int i = 0; i < fields.Length; i++)
                {
                    FieldInfo currentField = fields[i];
                    //CKitFieldAttribute attrib = Attribute.GetCustomAttribute(currentField, typeof(CKitFieldAttribute)) as CKitFieldAttribute;

                    List<KitFieldInfo> allLinks = new List<KitFieldInfo>();
                    allLinks.AddRange(currentKitComponent.m_commands);
                    allLinks.AddRange(currentKitComponent.m_inputs);
                    allLinks.AddRange(currentKitComponent.m_affecting);


                    KitFieldInfo kfi = allLinks.Find(t => t.rawFieldInfo.Equals(currentField));

                    if (kfi != null)
                    {

                        if (!(kfi.attribute is OptionAttribute))
                        {

                            if (currentField.FieldType.IsArray)
                            {
                                Array a = (Array)currentField.GetValue(currentKitComponent);
                                for (int j = 0; j < a.Length; j++)
                                {
                                    object sourceObject = a.GetValue(j);
                                    LinkToSourceValue(sourceObject, currentKitComponent, kfi);
                                }
                            }
                            else
                            {
                                object sourceObject = currentField.GetValue(currentKitComponent);
                                LinkToSourceValue(sourceObject, currentKitComponent, kfi);
                            }
                        }
                    }

                }
            }
            currentKitComponent.currentlySelected = false;
        }

        private static void LinkToSourceValue(object sourceObject, KitComponent currentComponent, KitFieldInfo kfi)
        {

            if (!(kfi.attribute is PrefabAttribute))
            {
                if (sourceObject != null)
                {
                    float activity = GizmoHelper.ActivityMinimumValue;
                    if (sourceObject is KitComponent)
                    {
                        if (((KitComponent)sourceObject).hideGizmos)
                        {
                            return;
                        }
                        else
                        {
                            activity = Mathf.Lerp(GizmoHelper.ActivityMinimumValue, GizmoHelper.ActivityPeakValue, ((KitComponent)sourceObject).Activity);
                        }


                    }

                    if (kfi.attribute is AffectsAttribute)
                    {
                        activity = Mathf.Max(currentComponent.Activity, activity);
                        Vector3 endPosition = ObjectPosition(sourceObject, "") + Vector3.left * KitFieldInfo.NODE_WIDTH / 1.1f;
                        //Vector3 direction = endPosition - kfi.NodePosition;

                        DrawArrow(kfi.NodePosition, endPosition, GizmoHelper.TypeColor(GizmoHelper.ClosestKitType(kfi)), activity);
                    }
                    else
                    {
                        Color color = Color.black;
                        if (kfi.attribute is DynamicInputAttribute && currentComponent is RememberFunction)
                        {
                            color = GizmoHelper.TypeColor(GizmoHelper.ClosestKitType(((RememberFunction)currentComponent).MyType()));
                        }
                        else if (kfi.rawFieldInfo.FieldType.IsArray)
                        {
                            color = GizmoHelper.TypeColor(GizmoHelper.ClosestKitType(kfi.rawFieldInfo.FieldType.GetElementType()));
                        }
                        else
                        {
                            color = GizmoHelper.TypeColor(GizmoHelper.ClosestKitType(kfi));
                        }
                        //Handles.Label(ObjectPosition(sourceObject, kfi.LinkName), kfi.LinkName);
                        DrawConnector(ObjectPosition(sourceObject, kfi.LinkName), kfi.NodePosition, color, activity);
                    }
                }
            }
        }

        /// <summary>
        /// Arrange and display connector nodes
        /// </summary>
        /// <remarks>This is done here rather than in the KitComponent to allow the use of Editor libraries</remarks>
        /// <param name="kc"></param>
        /// <param name="gizmoType"></param>
        private static void BuildSideArrays(out List<KitFieldInfo> leftHandFields,out List<KitFieldInfo> rightHandFields, KitComponent kc)
        {
            //int nodeRowPointer = 0;

            leftHandFields = new List<KitFieldInfo>();
            leftHandFields.AddRange(kc.m_commands);
            if (kc.m_commands.Count > 0)
            {
                //Insert a blank line.
                leftHandFields.Add(null);
            }
            leftHandFields.AddRange(kc.m_inputs);


            //for (int i = 0; i < leftHandFields.Count; i++)
            //{
            //    KitFieldInfo currentField = leftHandFields[i];
            //    if (currentField != null)
            //    {
            //        if (!(currentField.attribute is OptionAttribute))
            //        {
            //            nodeRowPointer++;

            //            currentField.LinkName = kc.LinkName(currentField);

            //            currentField.Edge = KitFieldInfo.BoxEdge.Left;
            //            currentField.Order = nodeRowPointer;


            //        }
            //    }
            //}

            //nodeRowPointer = 0;
            rightHandFields = new List<KitFieldInfo>();
            rightHandFields.AddRange(kc.m_outputs);
            if (kc.m_affecting.Count > 0)
            {
                
                rightHandFields.Add(null);
                rightHandFields.AddRange(kc.m_affecting);
            }

            //for (int i = 0; i < rightHandFields.Count; i++)
            //{
            //    nodeRowPointer++;
            //    KitFieldInfo currentField = rightHandFields[i];
            //    if (currentField != null)
            //    {
            //        currentField.Edge = KitFieldInfo.BoxEdge.Right;
            //        currentField.Order = nodeRowPointer;
            //    }
            //}

        }

        /// <summary>
        /// Arrange and display connector nodes
        /// </summary>
        /// <remarks>This is done here rather than in the KitComponent to allow the use of Editor libraries</remarks>
        /// <param name="kc"></param>
        /// <param name="gizmoType"></param>
        private static void DrawGUINodes(List<KitFieldInfo> leftHandFields, List<KitFieldInfo> rightHandFields, KitComponent kc, bool isDistant, int fontSize)
        {
            for (int i = 0; i < leftHandFields.Count; i++)
            {
                KitFieldInfo currentField = leftHandFields[i];
                if (currentField != null)
                {
                    if (!(currentField.attribute is OptionAttribute))
                    {
                        Gizmos.color = GizmoHelper.TypeColor(GizmoHelper.ClosestKitType(currentField));
                        Gizmos.DrawSphere(currentField.NodePosition, KitFieldInfo.NODE_HEIGHT / KitFieldInfo.DOT_SCALE);
                        GUIStyle labelStyle = new GUIStyle(GUI.skin.GetStyle("Label"));
                        labelStyle.alignment = TextAnchor.MiddleLeft;
                        labelStyle.normal.textColor = Color.white;
                        labelStyle.fontSize = Mathf.Clamp(fontSize,KitSettings.MinimumFontSize,KitSettings.MaximumFontSize);
                        if (!isDistant)
                            Handles.Label(currentField.NodePosition + Vector3.up * KitFieldInfo.NODE_HEIGHT / 2f + Vector3.right * KitFieldInfo.NODE_HEIGHT + Vector3.back * 0.1f, ObjectNames.NicifyVariableName(currentField.FieldName), labelStyle);
                    }
                }
            }

            for (int i = 0; i < rightHandFields.Count; i++)
            {
                KitFieldInfo currentField = rightHandFields[i];
                if (currentField != null)
                {
                    Gizmos.color = GizmoHelper.TypeColor(GizmoHelper.ClosestKitType(currentField));
                    Gizmos.DrawSphere(currentField.NodePosition, KitFieldInfo.NODE_HEIGHT / KitFieldInfo.DOT_SCALE);
                    GUIContent content = new GUIContent(ObjectNames.NicifyVariableName(currentField.FieldName));
                    GUIStyle labelStyle = new GUIStyle(GUI.skin.GetStyle("Label"));
                    labelStyle.alignment = TextAnchor.MiddleRight;
                    labelStyle.fontSize = Mathf.Clamp(fontSize, KitSettings.MinimumFontSize, KitSettings.MaximumFontSize); ;
                    labelStyle.contentOffset = new Vector2(-labelStyle.CalcSize(content).x, 0);
                    labelStyle.font.material.color = Color.white;

                    if (!isDistant)
                    {
                        Handles.Label(currentField.NodePosition + Vector3.up * KitFieldInfo.NODE_HEIGHT / 2f + Vector3.left * (KitFieldInfo.NODE_HEIGHT) + Vector3.back * 0.1f, content, labelStyle);
                        content.text = currentField.Value;

                        labelStyle.alignment = TextAnchor.MiddleLeft;
                        Vector2 offSetPosition = Vector2.zero;
                        offSetPosition.y -= labelStyle.CalcSize(content).y;
                        offSetPosition.x += 0;
                        labelStyle.contentOffset = offSetPosition;
                        Handles.Label(currentField.NodePosition + Vector3.right * KitFieldInfo.NODE_HEIGHT / KitFieldInfo.DOT_SCALE, content, labelStyle);
                    }
                }
            }


        }


        private static int CountGUINodes(KitComponent kc)
        {
            int nodeRowCount = 0;
            int nodeRowPointer = 0;

            //Left Hand Side
            //if (kc.m_commands.Count > 0)
            //    nodeRowPointer++;

            for (int i = 0; i < kc.m_commands.Count; i++)
            {
                nodeRowPointer++;
                nodeRowCount = Mathf.Max(nodeRowCount, nodeRowPointer);

            }

            for (int i = 0; i < kc.m_inputs.Count; i++)
            {
                if (!(kc.m_inputs[i].attribute is OptionAttribute))
                    nodeRowPointer++;
                nodeRowCount = Mathf.Max(nodeRowCount, nodeRowPointer);

            }

            nodeRowPointer = 0;
            //Right Hand Side
            if (kc.m_affecting.Count > 0)
                nodeRowPointer++;

            for (int i = 0; i < kc.m_affecting.Count; i++)
            {
                nodeRowPointer++;
                nodeRowCount = Mathf.Max(nodeRowCount, nodeRowPointer);

            }

            for (int i = 0; i < kc.m_outputs.Count; i++)
            {
                nodeRowPointer++;
                nodeRowCount = Mathf.Max(nodeRowCount, nodeRowPointer);

            }

            return nodeRowCount;
        }

        /// <summary>
        /// Draws a right-to-left curved connector between two locations.
        /// </summary>
        /// <param name="vFrom">The position of the start point</param>
        /// <param name="vTo">The position of the end point</param>
        /// <param name="color">The color for the line</param>
        /// <param name="activityLevel">The level of activity on the line expressed as a width in pixels</param>
        private static void DrawConnector(Vector3 vFrom, Vector3 vTo, Color color, float activityLevel)
        {
            float length = Mathf.Max(KitSettings.ConnectorLateralSpread, (vFrom - vTo).magnitude / 5f);
            Vector3 vt1 = vFrom + Vector3.right * length + Vector3.forward * KitFieldInfo.NODE_HEIGHT;
            Vector3 vt2 = vTo - Vector3.right * length + Vector3.forward * KitFieldInfo.NODE_HEIGHT;

            Handles.DrawBezier(vFrom, vTo, vt1, vt2, color, null, activityLevel);
        }

        private static void DrawArrow(Vector3 vFrom, Vector3 vTo, Color color, float activityLevel)
        {
            //vFrom += Vector3.forward;
            //vTo += Vector3.forward;
            float size = 0.5f;
            Vector3 vArrowEnd = vTo + Vector3.up * size;
            float length = (vFrom - vTo).magnitude / 5f;
            Handles.color = color;
            Handles.ArrowHandleCap(0, vArrowEnd, Quaternion.LookRotation(Vector3.down), size, EventType.Repaint);
            Handles.DrawBezier(vArrowEnd, vTo, vArrowEnd + (vTo - vArrowEnd) / 2f, vTo + (vArrowEnd - vTo) / 2f, color, null, activityLevel);
            Vector3 vt1 = vFrom + Vector3.right * length;// + Vector3.forward * KitFieldInfo.NODE_HEIGHT;
            if (vTo.y > vFrom.y)
                vt1 += Vector3.up * length;
            else
                vt1 -= Vector3.up * length;
            Vector3 vt2 = vArrowEnd + Vector3.up*size;// * length);// + Vector3.forward * NODE_HEIGHT;

            Handles.DrawBezier(vFrom, vArrowEnd, vt1, vt2, color, null, activityLevel);
        }

        /// <summary>
        /// Finds the position of the source object
        /// </summary>
        /// <param name="ob"></param>
        /// <returns></returns>
        private static Vector3 ObjectPosition(object ob, string outputName)
        {
            //if (outputName == "event")
            //    outputName = outputName;
            Vector3 result = Vector3.one;
            bool foundIt = false;
            if (ob != null)
            {
                if (ob is KitComponent)
                {
                    KitComponent other = (KitComponent)ob;
                    KitFieldInfo kfi = other.m_outputs.Find(t => t.FieldName.Equals(outputName));
                    if (kfi != null)
                    {
                        result = kfi.NodePosition;
                        foundIt = true;
                    }
                    else if (outputName != "")
                    {
                        Debug.LogFormat("Unable to find output field: {0} in component: {1}", outputName, other.GetType().Name);
                    }
                }
                if (ob is Component && !foundIt)
                {
                    result = ((Component)ob).transform.position;
                }
                else if (ob is GameObject && ob != null)
                {
                    GameObject gob = ((GameObject)ob);
                    Transform t = gob.GetComponent<Transform>();
                    if (t != null)
                    {
                        result = t.position;
                    }

                }
            }
            //if (Mathf.Approximately(result.x, -24.5f))
            //    result = result;
            return result;
        }

        /// <summary>
        /// Get the appropriate Kit Type for the component specified
        /// </summary>
        /// <param name="ob">Target component or parameter</param>
        /// <param name="attrib">Attribute of the parameter member</param>
        /// <returns></returns>
        private static Color ObjectKitType(object ob, Attribute attrib)
        {
            GizmoHelper.KitType kitType = GizmoHelper.KitType.Undefined;
            if (ob != null)
            {

                if (ob is FloatingPointValue)
                {
                    kitType = GizmoHelper.KitType.Float;
                }
                else if (ob is IntegerValue)
                {
                    kitType = GizmoHelper.KitType.Integer;
                }
                else if (ob is BooleanValue)
                {
                    kitType = GizmoHelper.KitType.Boolean;
                }
                else if (ob is VectorValue)
                {
                    kitType = GizmoHelper.KitType.Vector;
                }
                else if (ob is StringValue)
                {
                    kitType = GizmoHelper.KitType.String;
                }
                else if (ob is GameObjectValue)
                {
                    kitType = GizmoHelper.KitType.GameObject;
                }
                else if (ob is ColorValue)
                {
                    kitType = GizmoHelper.KitType.Color;
                }
                else if (ob is ActiveKitComponent && attrib is CommandAttribute)
                {
                    kitType = GizmoHelper.KitType.Signal;
                }
            }
            return GizmoHelper.TypeColor(kitType);
        }

        #endregion
    }
}
