using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anglia.CGTech.CKit.Effect
{
    [AddComponentMenu(MN.SET_SCALE)]
    [Summary(HD.EF_SET_SCL)]
    public class SetScale : FunctionKitComponent
    {
//pwdCS0219 
        [SerializeField]
        [Input(TT.IN_FLOAT)]
        private FloatingPointValue m_scale;
        [SerializeField]
        [Affects(TT.IN_GOB_AFF)]
        private GameObjectValue m_ObjectToScale;
        [SerializeField]
        [Setting(TT.ATTACH_MODE + TT.ATTACH_MODE_1 + TT.ATTACH_MODE_2 + TT.ATTACH_MODE_3 + TT.ATTACH_MODE_4)]
        private AttachmentMode m_attachMode = AttachmentMode.This;
//pwrCS0219 

        protected override void OnEnable()
        {
            base.OnEnable();
            IconManager.SetIcon(gameObject, IconManager.LabelIcon.Red);
        }

        internal override void InvokeProcess()
        {
            base.InvokeProcess();
            if (m_ObjectToScale != null && m_scale != null)
            {
                GameObject target = m_ObjectToScale.Fetch();
                if (target != null)
                {
                    target.transform.localScale = m_scale.Fetch() * Vector3.one;
                }
            }

        }

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Effect;
            }
        }
        
    }

}

