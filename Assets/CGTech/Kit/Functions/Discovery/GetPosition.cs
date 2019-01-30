using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Discovery
{
    [AddComponentMenu(MN.GetPosition)]
    [Summary(HD.GOS_2_VEC)]
    public class GetPosition : FunctionKitComponent
    {

        [SerializeField]
        [Input(TT.IN_GOS)]
        private GameObjectValue m_source;

        [SerializeField]
        [Output(TT.OUT_CURRENT_VAL)]
        private Vector2 m_currentValue;

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Discovery;
            }
        }

        internal override void InvokeProcess()
        {
            base.InvokeProcess();
            GameObject gob = m_source.Fetch();
            if (gob != null)
            {
                m_currentValue = new Vector2(gob.transform.position.x, gob.transform.position.y);
            }
            else
            {
                Debug.LogWarningFormat(WM.IN_NO_TGT_FOUND, GetType().Name, gameObject.name);
            }
            SendCommandSignal();
        }



        protected override void DrawGizmos()
        {
            if (m_source != null)
            {
                GizmoHelper.DrawArrow(m_source.transform.position, transform.position, GizmoHelper.KitType.GameObject);
            }
            GizmoHelper.DrawArrow(new Vector3(m_currentValue.x, m_currentValue.y, 0f), transform.position, GizmoHelper.KitType.Vector);
        }


    }
}
