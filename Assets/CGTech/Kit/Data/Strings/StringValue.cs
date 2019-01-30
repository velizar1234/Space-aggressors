using Anglia.CGTech.CKit.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Anglia.CGTech.CKit.Data
{
    public abstract class StringValue : GenericDataSource<string>
    {

        //public abstract string Fetch(bool force=false);
        //[SerializeField]
        //[Output(TT.OUT_CURRENT_VAL)]
        //protected string m_currentValue;

        //public string CurrentValue
        //{
        //    get
        //    {
        //        return m_currentValue;
        //    }

        //    set
        //    {
        //        Activity = GizmoHelper.ActivityPeakValue;
        //        m_currentValue = value;
        //    }
        //}

        public override string Add(string other)
        {
            return other+Fetch();
        }

        protected override void LateUpdate()
        {
#if UNITY_EDITOR
            Fetch();
#endif
            base.LateUpdate();
        }
    }
}