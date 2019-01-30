using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

namespace Anglia.CGTech.CKit.Helper
{
    public class KitFieldInfo
    {
        public enum BoxEdge
        {
            Undefined = 0,
            Left,
            Right,
            Top,
            Bottom
        }
        public const float DEFAULT_OFFSET = 0.15f;
        public const float NODE_WIDTH = 1f;
        public const float NODE_HEIGHT = 0.15f;
        public const float DOT_SCALE = 3f;

        KitComponent m_targetComponent = null;
        BoxEdge m_edge = BoxEdge.Right;

        public KitFieldInfo(FieldInfo fi, KitComponent targetComponent)
        {
            rawFieldInfo = fi;
            m_targetComponent = targetComponent;
            //NodePosition = targetComponent.transform.position;
        }

        public FieldInfo rawFieldInfo;

        public CKitFieldAttribute attribute
        {
            get
            {
                if (m_attribute == null)

                    if (rawFieldInfo != null)
                        m_attribute = Attribute.GetCustomAttribute(rawFieldInfo, typeof(CKitFieldAttribute)) as CKitFieldAttribute;

                return m_attribute;
            }
        }

        public string FieldName
        {
            get
            {
                if (rawFieldInfo != null)
                    return rawFieldInfo.Name;
                else
                    return "event";
            }
        }

        private string linkName;
        private CKitFieldAttribute m_attribute;


        //private Vector3 nodePosition;

        public Vector3 NodePosition
        {
            get
            {
                Vector3 result = m_targetComponent.transform.position;
                switch (m_edge)
                {
                    case BoxEdge.Left:
                        result += new Vector3(-NODE_WIDTH, -((float)(Order) + 0.5f) * NODE_HEIGHT, -0.0f);
                        break;
                    case BoxEdge.Right:
                        result += new Vector3(+NODE_WIDTH, -((float)(Order) + 0.5f) * NODE_HEIGHT, 0f);
                        break;
                    default:
                        break;
                }
                return result;
            }

        }

        public Type DataType
        {
            get
            {
                if (rawFieldInfo != null)
                    return rawFieldInfo.FieldType;
                else
                    return typeof(CommandSignal);
            }
        }

        public string LinkName
        {
            get
            {
                if (attribute != null)
                    return attribute.LinkName;
                else
                    return linkName;
            }

            set
            {
                if (attribute != null)
                    attribute.LinkName = value;
                else
                    linkName = value;
            }

        }

        public KitComponent TargetComponent
        {
            get
            {
                return m_targetComponent;
            }

            set
            {
                m_targetComponent = value;
            }
        }

        public BoxEdge Edge
        {
            get
            {
                return m_edge;
            }

            set
            {
                m_edge = value;
            }
        }

        private int m_order = 1;
        public int Order
        {
            get
            {
                return m_order;
            }
            set
            {
                m_order = value;
            }
        }
        public string Value
        {
            get
            {
                string sResult = "";
                object result = null;
                if (TargetComponent != null && rawFieldInfo != null)
                {
                    result = rawFieldInfo.GetValue(TargetComponent);
                    if (result != null)
                    {
                        if (result is float)
                        {
                            sResult = ((float)result).ToString("#,##0.00");
                        }
                        else if (result is MonoBehaviour)
                        {
                            sResult = ((MonoBehaviour)result).name;
                        }
                        else
                        {
                            sResult = result.ToString();
                        }
                    }
                }
                return sResult;
            }
        }
    }
}