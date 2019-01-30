using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Input
{
    /// <summary>
    /// The ExtractGameObject component gets a reference to a game object. 
    /// If a target gameObject is provided, the component output will be the latest value output by that source.
    /// </summary>
    [AddComponentMenu("Construction Kit/Discover/Extract Game Object")]
    [Summary(HD.GOB_2_GOS)]
    public class ExtractGameObject : GameObjectValue
    {

        [SerializeField]
        [Input (TT.TGT_GOB)]
        private GameObject m_target;

        [SerializeField]
        [Setting(TT.ATTACH_MODE+TT.ATTACH_MODE_1+TT.ATTACH_MODE_2+TT.ATTACH_MODE_3+TT.ATTACH_MODE_4)]
        private AttachmentMode m_mode = AttachmentMode.This;

        
        //This method defines the gizmo colour to use for the label.
        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Discovery;
            }
        }
        protected override void DrawGizmos()
        {
            if (m_target != null)
            {
                GizmoHelper.DrawArrow(m_target.transform.position, transform.position, GizmoHelper.KitType.GameObject);
            }
            if (m_currentValue != null)
            {
                GizmoHelper.DrawArrow(m_currentValue.transform.position, transform.position, GizmoHelper.KitType.GameObject);
            }
        }

        public override GameObject Fetch()
        {
            if (!m_calculatedThisFrame)
            {
                m_calculatedThisFrame = true;

                m_currentValue = PickTarget(m_mode, m_target);

            }
            return m_currentValue;
        }

    }
}