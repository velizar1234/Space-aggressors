using Anglia.CGTech.CKit.Data;
using System;
using UnityEngine;

namespace Anglia.CGTech.CKit.Helper
{
    public abstract class CommandSignal : ActiveKitComponent
    {


    }

    public abstract class FunctionKitComponent : ActiveKitComponent
    {
        [Command]
        [SerializeField]
        protected ActiveKitComponent m_doAfter = null;
    }

   
}
