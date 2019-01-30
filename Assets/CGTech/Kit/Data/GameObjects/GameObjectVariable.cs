using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Data
{
    /// <summary>
    /// The Game Object Value component holds a game object reference value.  
    /// If an input source is provided, the store will hold the latest value output by that source.
    /// </summary>
    [AddComponentMenu(MN.GameObjectVariable)]
    [Summary (HD.GOB_STORE)]
    public class GameObjectVariable : GameObjectValue
    {
        [SerializeField]
        [Input(TT.IN_STORE_SOURCE)]
        private GameObjectValue m_source;

        protected override GenericDataSource<GameObject> Source
        {
            get
            {
                return m_source;
            }
        }
   

        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Storage;
            }
        }

    }
}
