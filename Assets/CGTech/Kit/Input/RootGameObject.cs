using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Input
{
    /// <summary>
    /// The ExtractGameObject component gets a reference to a game object. 
    /// If a target gameObject is provided, the component output will be the latest value output by that source.
    /// </summary>
    [AddComponentMenu(MN.ROOT_GAME_OBJECT)]
    [Summary(HD.GOB_2_GOS)]
    public class RootGameObject : GameObjectValue
    {

        //This method defines the gizmo colour to use for the label.
        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Input;
            }
        }


        public override GameObject Fetch()
        {
            GameObject result = null;
            if (this.transform.root != null)
            {
                result = this.transform.root.gameObject;
                m_currentValue = result;
            }
            return result;
        }

    }
}