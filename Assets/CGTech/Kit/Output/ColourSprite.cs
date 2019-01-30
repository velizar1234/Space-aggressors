using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Anglia.CGTech.Kit.Output
{
    [AddComponentMenu("Construction Kit/Effect/Color Sprite")]
    [Summary(HD.EF_SET_COLOR)]
    public class ColourSprite : KitComponent
    {
        [SerializeField]
        [Input(TT.ST_COLOR)]
        private ColorValue m_color;

        [SerializeField]
        [Input(TT.TGT_SPRITE)]
        private SpriteRenderer m_targetSprite;


        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Effect;
            }
        }

        protected override void Update()
        {
            base.Update();
            if (m_targetSprite != null && m_color != null)
            {
                m_targetSprite.color = m_color.Fetch();
            }
            else
            {
                Debug.LogWarningFormat(WM.IN_NULL, GetType().Name, gameObject.name);
            }


        }
    }
}
