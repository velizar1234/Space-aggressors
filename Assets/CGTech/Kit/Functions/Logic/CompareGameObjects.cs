using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Functions
{
    [AddComponentMenu(MN.FN_COMPARE_GOB)]
    [Summary(HD.FN_COMPARE)]
    public class CompareGameObjects : BooleanValue
    {

        [SerializeField]
        [Input(TT.IN_VEC)]
        private GameObjectValue m_ObjectOne;
        [SerializeField]
        [Input(TT.IN_VEC)]
        private GameObjectValue m_ObjectTwo;



        public override bool Fetch()
        {
            m_currentValue = false;
            if (m_ObjectOne != null && m_ObjectTwo != null)
            {
                GameObject firstVector = m_ObjectOne.Fetch();
                GameObject secondVector = m_ObjectTwo.Fetch();
                m_currentValue = firstVector == secondVector;
            }
            return m_currentValue;
        }

        #region HFC
        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.ProcessActive;
            }
        }

        protected override void DrawGizmos()
        {
            if (m_ObjectOne != null)
            {
                GizmoHelper.DrawArrow(m_ObjectOne.transform.position, transform.position, GizmoHelper.KitType.Vector);
            }

            if (m_ObjectTwo != null)
            {
                GizmoHelper.DrawArrow(m_ObjectTwo.transform.position, transform.position, GizmoHelper.KitType.Vector);
            }


        }


        #endregion
    }
}
