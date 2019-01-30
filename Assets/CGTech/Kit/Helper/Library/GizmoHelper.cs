using Anglia.CGTech.CKit.Data;
using System;
//using UnityEditor;
using UnityEngine;

namespace Anglia.CGTech.CKit.Helper
{
    public static class GizmoHelper
    {
        static Color brown = new Color(.5f, .2f, .2f);
        static Color activeBackground = new Color(.0f, .0f, .2f);
        static Color rayColor = new Color(.6f, .6f, 1f);
        private static Color KitColorObject = new Color(0.5f,1f,0.5f,1f);
        private static Color KitColorInteger = new Color(0.1f, 0.1f, 1f, 1f);
        private static Color KitColorFloat = new Color(0.5f, 0.5f, 1f, 1f);
        public static Color KitColorSignal = new Color(0.95f, 0.95f, 1f, 1f);
        public static Color KitColorColor = new Color(1f, .7f, .7f, 1f);

        public static float ActivityMinimumValue
        {
            get
            {
                return 1.5f;
            }
        }

        public static float ActivityFadeDuration
        {
            get
            {
                return 3.5f;
            }
        }

        public static float ActivityPeakValue
        {
            get
            {
                return 5.0f;
            }
        }

        public static float ActivityMediumValue
        {
            get
            {
                return 3f;
            }
        }

        public static Color Brown
        {
            get
            {
                return brown;
            }


        }

        public static Color ActiveBackground
        {
            get
            {
                return activeBackground;
            }

           
        }

        public static Color Lighten(Color color)
        {

            Color result = new Color((color.r+1f)/2f, (color.g + 1f) / 2f, (color.b + 1f) / 2f);
            return result;
        }

        public enum GizmoColor
        {
            Undefined = 0,
            StoreValue,
            RetreiveValue,
            ModifyValue
        }

        public enum KitType
        {
            Undefined = 0,
            Integer,
            Float,
            Vector,
            Boolean,
            GameObject,
            String,
            Color,
            Signal,
            Ray
        }

        public enum PartType
        {
            Undefined = 0,
            Discovery,
            Input,
            Storage,
            ProcessActive,
            Effect,
            Block,
            Assistant,
            ProcessPassive,
            Event
        }

        public static Color TypeColor(KitType t)
        {
            Color result = Color.black;
            switch (t)
            {
                case KitType.Integer:
                    result = KitColorInteger;
                    break;
                case KitType.Color:
                    result = KitColorColor;
                    break;
                case KitType.Vector:
                    result = Color.cyan;
                    break;
                case KitType.GameObject:
                    result = KitColorObject;
                    break;
                case KitType.Boolean:
                    result = Color.magenta;
                    //    result = Color.white;
                    break;
                case KitType.String:
                    result = Color.red;
                    break;
                case KitType.Signal:
                    result = KitColorSignal;
                    break;
                case KitType.Float:
                    result = KitColorFloat;
                    break;
                case KitType.Ray:
                    result = rayColor;
                    break;
                default:
                    result = brown;
                    break;

            }


            return result;
        }

        public static KitType ClosestKitType(KitFieldInfo kfi)
        {
            
            if (kfi.DataType == typeof(FunctionKitComponent))
            {
                if (kfi.attribute is InputAttribute)
                {
                    return  ClosestKitType(((InputAttribute)kfi.attribute).MatchingType);
                }
            }
            if (kfi.DataType == typeof(ActiveKitComponent) && kfi.FieldName=="event")
            {
                return KitType.Signal;
            }
            return ClosestKitType(kfi.DataType);
        }

        public static KitType ClosestKitType(Type type)
        { 
            if (type.IsArray)
            {
                type = type.GetElementType();
            }
             
            KitType result = KitType.Undefined;
            if (type == typeof(int) || type == typeof(IntegerValue))
            {
                result = KitType.Integer;
            }
            else if (type == typeof(float) || type == typeof(FloatingPointValue))
            {
                result = KitType.Float;
            }
            else if (type == typeof(ActiveKitComponent) || type == typeof(CommandSignal) || type == typeof(FunctionKitComponent) )
            {
                result = KitType.Signal;
            }
            else if (type == typeof(GameObjectValue) || type == typeof(GameObject))
            {
                result = KitType.GameObject;
            }
            else if (type == typeof(Rigidbody2D)|| type == typeof(RigidBodyValue))
            {
                result = KitType.GameObject;
            }
            else if (type == typeof(BooleanValue) || type == typeof(bool))
            {
                result = KitType.Boolean;
            }
            else if (type == typeof(StringValue) || type == typeof(string) || type == typeof(StringVariable))
            {
                result = KitType.String;
            }
            else if (type == typeof(VectorValue) || type == typeof(Vector2) || type == typeof(Vector3))
            {
                result = KitType.Vector;
            }
            else if (type == typeof(RayValue) || type == typeof(RayVariable))
            {
                result = KitType.Vector;
            }
            else if (type == typeof(ColorValue) || type == typeof(Color) || type == typeof(Color32))
            {
                result = KitType.Color;
            }
            else if (type == typeof(RayValue) || type == typeof(Ray2D))
            {
                result = KitType.Ray;
            }
            else
            {
                Debug.LogFormat("Unrecognised {0} type for colour selection.",type);
            }

            return result;
        }

        public static IconManager.LabelIcon TypeGizmo(PartType t)
        {
            IconManager.LabelIcon result = IconManager.LabelIcon.Gray;
            switch (t)
            {
                case PartType.Discovery:
                    result = IconManager.LabelIcon.Green;
                    break;
                case PartType.Input:
                    result = IconManager.LabelIcon.Teal;
                    break;
                case PartType.Storage:
                    result = IconManager.LabelIcon.Gray;
                    break;
                case PartType.ProcessActive:
                    result = IconManager.LabelIcon.Orange;
                    break;
                case PartType.ProcessPassive:
                    result = IconManager.LabelIcon.Yellow;
                    break;
                case PartType.Effect:
                    result = IconManager.LabelIcon.Red;
                    break;
                case PartType.Block:
                    result = IconManager.LabelIcon.Gray;
                    break;
                case PartType.Event:
                    result = IconManager.LabelIcon.Purple;
                    break;
                default:
                    result = IconManager.LabelIcon.None;
                    break;

            }


            return result;
        }




        public static void DrawArrow(Vector3 from, Vector3 to, KitType kType)
        {
            Gizmos.color = TypeColor(kType);

            Gizmos.DrawLine(from, to);
            Vector3 midpoint = (to - from) * .5f + from;
            Vector3 arrowpoint = (to - from) * .55f + from;

            Vector3 scaleV = (arrowpoint - midpoint);
            Vector3 leftPoint = midpoint;
            leftPoint.x += scaleV.y;
            leftPoint.y -= scaleV.x;

            Gizmos.DrawLine(leftPoint, arrowpoint);

            Vector3 rightPoint = midpoint;
            rightPoint.x -= scaleV.y;
            rightPoint.y += scaleV.x;

            Gizmos.DrawLine(rightPoint, arrowpoint);

        }

        //private static void SetColor(GizmoColor color)
        //{
        //    Color result = Color.white;
        //    switch (color)
        //    {
        //        case GizmoColor.StoreValue:
        //            result = Color.red;
        //            break;
        //        case GizmoColor.RetreiveValue:
        //            result = Color.yellow;
        //            break;
        //        case GizmoColor.ModifyValue:
        //            result = Color.magenta;
        //            break;
        //    }
        //    Gizmos.color = result;
        //}

        public static void SetUnityGizmo(GameObject target, PartType partType)
        {
            if (partType != PartType.Assistant)
                IconManager.SetIcon(target, TypeGizmo(partType));
        }

        public static void DrawLabel(Vector3 position, string text, Color color)
        {
            GUIStyle style = new GUIStyle();
            style.fontStyle = FontStyle.Bold;
            style.fontSize = 12;
            style.alignment = TextAnchor.LowerLeft;
            style.normal.textColor = color;
            //style.font.material.color = Color.white;
            //GUIContent content = new GUIContent(ObjectNames.NicifyVariableName(text));

            //Handles.Label(position, content, style);

        }
    }
}
