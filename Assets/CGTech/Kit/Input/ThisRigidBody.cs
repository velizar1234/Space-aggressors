using Anglia.CGTech.CKit.Data;
using Anglia.CGTech.CKit.Helper;
using UnityEngine;

namespace Anglia.CGTech.CKit.Input
{
    /// <summary>
    /// The ThisGameObject component gets a reference to the game object to which it is attached. 
    /// </summary>
    [AddComponentMenu(MN.INP+"[Import] RigidBody")]
    public class ThisRigidBody : RigidBodyValue
    {

        //This method defines the gizmo colour to use for the label.
        protected override GizmoHelper.PartType PartType
        {
            get
            {
                return GizmoHelper.PartType.Discovery;
            }
        }

        public override Rigidbody2D Fetch()
        {
            return this.gameObject.GetComponent<Rigidbody2D>();
        }


    }
}