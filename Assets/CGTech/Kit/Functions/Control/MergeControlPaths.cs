using Anglia.CGTech.CKit.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Summary(HD.MERGE)]
public class MergeControlPaths : CommandSignal
{
    [Command]
    public ActiveKitComponent[] m_sources;

    protected override GizmoHelper.PartType PartType
    {
        get
        {
            return GizmoHelper.PartType.Block;
        }
    }

    internal override void InvokeProcess()
    {
        base.InvokeProcess();
        SendCommandSignal();
    }

}
