
using Anglia.CGTech.CKit.Helper;
using Anglia.CGTech.CKit.Helper.Library;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Anglia.CGTech.CKit.Data
{


    [System.Serializable]
    public abstract class GenericDataSource<T> : GenericDataFramework
    {

        [Ignore]
        protected bool m_calculatedThisFrame;

        private bool m_wasValuePushed;

        /// <summary>
        /// True if the value held in this component was pushed into it via a property call.
        /// Set this in the CurrentValue property set of subclasses.
        /// </summary>
        public bool WasValuePushed
        {
            get
            {
                return m_wasValuePushed;
            }

            protected set
            {
                m_wasValuePushed = value;
            }
        }

        [ExecuteInEditMode]
        protected override void OnEnable()
        {
            base.OnEnable();
            KitVersion.CreateKitVersion();
            BindFunctionSourceField();
        }

        public override void OnPropertyChange()
        {
            base.OnPropertyChange();
            BindFunctionSourceField();
        }

        protected override void Update()
        {
            base.Update();
            if (m_functionSource != null)
            {
                Activity = m_functionSource.Activity;
            }
            m_calculatedThisFrame = false;
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
            m_calculatedThisFrame = false;
#if UNITY_EDITOR
            Fetch();
#endif
        }

        protected GameObject PickTarget(AttachmentMode attachMode, GameObjectValue target = null)
        {
            GameObject gob = null;
            if (target != null)
            {
                gob = target.Fetch();
            }
            return (PickTarget(attachMode, gob));
        }


        protected GameObject PickTarget(AttachmentMode attachMode, GameObject target = null)
        {
            GameObject result = null;
            switch (attachMode)
            {
                case AttachmentMode.Target:
                    if (target != null)
                    {
                        result = target;
                    }
                    else
                    {
                        Debug.LogWarningFormat(WM.IN_NULL, this.GetType().Name, gameObject.name);
                    }
                    break;
                case AttachmentMode.This:
                    result = gameObject;
                    break;
                case AttachmentMode.Parent:
                    if (transform.parent != null)
                        result = transform.parent.gameObject;
                    break;
                case AttachmentMode.Root:
                    if (transform.root != null)
                        result = transform.root.gameObject;
                    break;
                default:
                    Debug.LogWarningFormat(WM.ATTACH_MODE_UNSUPPORTED, attachMode, this.GetType().ToString(), gameObject.name);
                    break;
            }

            return result;
        }

        public override Type MyType()
        {
            return typeof(T);
        }

        public override string ValueToString()
        {
            return m_currentValue.ToString();
        }

        [SerializeField]
        [Output(TT.OUT_CURRENT_VAL)]
        protected T m_currentValue = default(T);

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Undefined;
            }
        }

        protected virtual GenericDataSource<T> Source
        {
            get
            {
                Debug.LogWarningFormat(WM.NO_OVERRIDE, "Source", this.GetType().ToString(), gameObject.name);
                return null;
            }
        }



        public virtual T Fetch()
        {
            bool isConst = true;
            // Value Priority
            // FunctionTarget >> FunctionSource >> Source
            if (WasValuePushed)
            {
                isConst = false;
                if (Source != null || FunctionSource != null)
                {
                    m_messages.Display(WM.DUAL_INPUT);
                }
            }
            else
            {
                if (Source != null)
                {
                    m_currentValue = Source.Fetch();
                    isConst = false;
                }


                if (FunctionSource != null)
                {
                    if (Source != null)
                    {
                        m_messages.Display("Function source overrides variable source.");
                        //Source = null;
                    }
                    object ob = kfi.rawFieldInfo.GetValue(m_functionSource);
                    if (ob != null && ob is T)
                    {
                        m_currentValue = (T)ob;
                        isConst = false;
                    }
                    else if (ob == null)
                    {
                        m_currentValue = default(T);
                        isConst = false;
                    }
                }
            }


            if (isConst)
            {
                m_messages.Display(IM.CONST_MODE);
            }

            return m_currentValue;
        }

        //public virtual T Fetch()
        //{
        //    T result = default(T);
        //    result = m_currentValue;
        //    return result;
        //}

        public T CurrentValue
        {
            get
            {
                return m_currentValue;
            }
            set
            {
                Activity = 1f;
                WasValuePushed = true;
                m_currentValue = value;
            }
        }


        public virtual T Add(T other)
        {
            T result = default(T);
            return result;
        }

    }

}
