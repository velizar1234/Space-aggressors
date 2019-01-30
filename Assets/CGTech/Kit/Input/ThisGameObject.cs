using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Input
{
    /// <summary>
    /// The ThisGameObject component gets a reference to the game object to which it is attached. 
    /// </summary>
    [AddComponentMenu(MN.THIS_GAME_OBJECT)]
    [Summary(HD.GOB_2_GOS)]
    public class ThisGameObject : GameObjectValue
    {

        //This method defines the gizmo colour to use for the label.
        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Discovery;
            }
        }
        

        public override GameObject Fetch()
        {
            m_currentValue = this.gameObject;
            return m_currentValue;
        }

        protected override bool DontSnap
        {
            get
            {
                return true;
            }
        }

    }
}