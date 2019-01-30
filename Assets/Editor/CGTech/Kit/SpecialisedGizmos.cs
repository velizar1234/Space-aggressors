using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEditor;
using UnityEngine;
namespace Anglia.Editor.CGTech.Kit
{
    public static class SpecialisedGizmos
    {


        public static bool Draw(KitComponent target, bool isDistant, int fontSize)
        {
            bool result = false;

            if (target is LogicBlock)
            {
                result = DrawLogicBlockGizmo(target as LogicBlock, isDistant, fontSize);
            }
            else if (target is Comment)
            {
                result = DrawCommentGizmo(target as Comment, isDistant, fontSize);
            }
            else if (target is RayVariable)
            {
                result = DrawRayVariableGizmo(target as RayVariable, isDistant, fontSize);
            }

            return result;

        }

        public static bool DrawLogicBlockGizmo(LogicBlock target, bool isDistant, int fontSize)
        {
            target.windowDisplayRect = new Rect(target.transform.position, Vector2.zero);
            Bounds boundary = new Bounds(target.transform.position, Vector3.zero);
            boundary = target.EncapsulateChildren(boundary, target.transform);
            Gizmos.color = target.BoxColor;
            Vector3 offset = target.transform.position - boundary.center;
            switch (target.Mode)
            {
                case GizmoDrawFrame.Solid:
                    Gizmos.DrawCube(boundary.center - offset * (target.ScaleFactor - 1f), boundary.size * target.ScaleFactor);
                    Color frameColor = target.BoxColor;
                    frameColor.a = 1f;
                    Gizmos.color = frameColor;
                    Gizmos.DrawWireCube(boundary.center - offset * (target.ScaleFactor - 1f), boundary.size * target.ScaleFactor);
                    break;
                case GizmoDrawFrame.Wireframe:
                    Gizmos.DrawWireCube(boundary.center - offset * (target.ScaleFactor - 1f), boundary.size * target.ScaleFactor);
                    break;
                default:
                    Debug.LogWarningFormat(WM.MODE_UNSUPPORTED, target.Mode.ToString(), target.GetType().Name, target.gameObject.name);
                    break;

            }
            return true;
        }

        public static bool DrawCommentGizmo(Comment target, bool isDistant, int fontSize)
        {
            if (!isDistant)
            {
                GUIStyle labelStyle = new GUIStyle(GUI.skin.GetStyle("Label"));
                labelStyle.fontSize = fontSize;
                labelStyle.normal.textColor = target.Color;
                GUIContent content = new GUIContent(target.m_commentText);
                Handles.Label(target.transform.position, target.m_commentText, labelStyle);
            }
            return true;
        }

        public static bool DrawRayVariableGizmo(RayVariable target, bool isDistant, int fontSize)
        {
            target.Calculate();
            Gizmos.DrawRay(target.Ray2Dto3D(target.CurrentValue));

            return false;
        }
    }
}