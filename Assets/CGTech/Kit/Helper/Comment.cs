
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Anglia.CGTech.CKit.Helper
{
    [AddComponentMenu(MN.COMMENT)]
    [Summary(HD.COMMENT)]
    public class Comment : KitComponent
    {
        [Setting(Required.Optional, TT.COMMENT)]
        [TextArea(3, 5)]
        public string m_commentText;
        [Setting(Required.Optional, TT.ST_COLOR)]
        [SerializeField]
        private Color m_color = Color.white;

        protected override bool DontSnap
        {
            get
            {
                return true;
            }
        }

        public Color Color
        {
            get
            {
                return m_color;
            }
        }

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Assistant;
            }
        }
    }
}