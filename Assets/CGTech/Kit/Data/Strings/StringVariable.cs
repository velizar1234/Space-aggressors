using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Data
{
    /// <summary>
    /// The String Store component holds a text string.  
    /// If an input source is provided, the store will hold the latest value output by that source.
    /// </summary>
    [AddComponentMenu(MN.StringVariable)]
    [Summary(HD.STR_STORE)]
    public class StringVariable : StringValue
    {
        [SerializeField]
        [Input(TT.IN_STORE_SOURCE)]
        private StringVariable m_source;

        //public override string Fetch()
        //{
        //    if (m_source != null)
        //    {
        //        if (WasValuePushed)
        //        {
        //            Debug.LogErrorFormat(WM.DUAL_INPUT, GetType().Name, gameObject.name);
        //        }
        //        else
        //        {
        //            m_currentValue = m_source.Fetch();
        //        }
        //    }
        //    return m_currentValue;
        //}

        protected override GenericDataSource<string> Source
        {
            get
            {
                return m_source;
            }
        }

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Storage;
            }
        }

    }
}
