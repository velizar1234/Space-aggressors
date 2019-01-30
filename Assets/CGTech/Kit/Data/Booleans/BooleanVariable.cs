
using UnityEngine;
using Anglia.CGTech.CKit.Helper;


namespace Anglia.CGTech.CKit.Data
{
    /// <summary>
    /// The Boolean Variable component holds a boolean (true/false) value.  
    /// If an input source is provided, the store will hold the latest value output by that source.
    /// </summary>
    [AddComponentMenu(MN.BooleanVariable)]
    [Summary(HD.BOOL_STORE + HD.VARIABLE)]
    public class BooleanVariable : BooleanValue
    {

        [SerializeField]
        [Input(TT.IN_STORE_SOURCE)]
        private BooleanValue m_source;

        protected override GenericDataSource<bool> Source
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