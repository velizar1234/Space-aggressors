using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Data
{
    [Summary(HD.COL_STORE)]
    [AddComponentMenu(MN.ColorVariable)]
    public class ColorVariable : ColorValue
    {
        [SerializeField]
        [Input(TT.IN_STORE_SOURCE)]
        private ColorValue m_source;

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Storage;
            }
        }

        protected override GenericDataSource<Color> Source
        {
            get
            {
                return m_source;
            }
        }

    }
}
