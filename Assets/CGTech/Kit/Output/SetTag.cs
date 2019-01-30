using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anglia.CGTech.CKit.Output
{
    [AddComponentMenu("Construction Kit/Effect/Set Tag")]
    [Summary(HD.EF_SET_TAG)]
    public class SetTag : KitComponent
    {
        
        [SerializeField]
        [Input(TT.IN_ACT_BOOL)]
        private BooleanValue m_setNow;
        [SerializeField]
        [Affects(TT.EFF_GOS)]
        private GameObjectValue m_objectToEdit;
        [SerializeField]
        [Input(TT.IN_TAG_STR)]
        private StringValue m_tagString;

        GameObject gob = null;
        protected override void Update()
        {
            base.Update();
            if (m_objectToEdit != null && m_setNow != null)
            {
                if (m_setNow.Fetch() && m_objectToEdit != null && m_tagString != null)
                {
                    gob = m_objectToEdit.Fetch();
                    if (gob != null)
                    {
                        gob.tag = m_tagString.Fetch();
                    }
                }
            }
        }
        /* 
                    _.---._
                _.-~       ~-._
            _.-~               ~-._
        _.-~                       ~---._
    _.-~                                 ~\
 .-~                                    _.;
 :-._                               _.-~ ./
 }-._~-._                   _..__.-~ _.-~)
 `-._~-._~-._              / .__..--~_.-~
     ~-._~-._\.        _.-~_/ _..--~~
         ~-. \`--...--~_.-~/~~
            \.`--...--~_.-~
              ~-..----~ */

        #region Helpful functionality code, it is not essential to understand at level 4
        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Effect;
            }
        }
        protected override void DrawGizmos()
        {
            if (m_objectToEdit != null)
            {
                GizmoHelper.DrawArrow(transform.position, m_objectToEdit.transform.position, GizmoHelper.KitType.GameObject);
            }
            if (gob != null)
            {
                GizmoHelper.DrawArrow(gob.transform.position, transform.position, GizmoHelper.KitType.GameObject);
            }
            if (m_setNow != null)
            {
                GizmoHelper.DrawArrow(m_setNow.transform.position, transform.position, GizmoHelper.KitType.Boolean);
            }
            if (m_tagString != null)
            {
                GizmoHelper.DrawArrow(m_tagString.transform.position, transform.position, GizmoHelper.KitType.String);
            }


            //UnityEditor.Handles.color = stringpair.color.HasValue ? stringpair.color.Value : Color.green;
            //UnityEditor.Handles.Label(transform.position, "Test");

        }
        #endregion
    }
}
