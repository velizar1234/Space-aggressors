using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Output
{
    [AddComponentMenu("Construction Kit/Effect/Colour Lerp")]
    [Summary(HD.FN_LERP_COL)]
    public class ColorLerp : FunctionKitComponent
    {

        [Setting(TT.IN_COL1)]
        [SerializeField]
        private Color m_startColor = Color.white;

        [SerializeField]
        [Setting(TT.IN_COL2)]
        private Color m_midColor = Color.yellow;

        [SerializeField]
        [Setting(TT.IN_COL3)]
        private Color m_endColor = Color.black;

        [SerializeField]
        [Affects(TT.TGT_SPRITE)]
        private SpriteRenderer m_targetSprite;

        [SerializeField]
        [Setting(TT.IN_FLOAT_DUR)]
        private float m_duration = 1f;

        [Output(TT.TODO)]
        private bool m_started = false;

        [SerializeField]
        [Output(TT.OUT_CURRENT_VAL)]
        internal float elapsedTime = 0f;

        [SerializeField]
        [Output(TT.OUT_CURRENT_VAL)]
        protected Color32 m_currentColor = Color.white;

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Effect;
            }
        }

        internal override void InvokeProcess()
        {
            base.InvokeProcess();
            m_started = true;
            SendCommandSignal();
        }

        protected override void Update()
        {
            base.Update();
            if (m_started && Application.isPlaying)
            {
                elapsedTime += Time.deltaTime;
                float progressFactor = Mathf.Clamp01(elapsedTime / m_duration);
                if (m_targetSprite != null)
                {
                    if (progressFactor < 0.5f)
                    {
                        m_currentColor = Color.Lerp(m_startColor, m_midColor, progressFactor * 2f);
                    }
                    else
                    {
                        m_currentColor = Color.Lerp(m_midColor, m_endColor, (progressFactor - 0.5f) * 2f);
                    }
                }
                m_targetSprite.color = m_currentColor;
            }

        }

    }
}