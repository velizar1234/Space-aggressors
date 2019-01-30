using Anglia.CGTech.CKit.Helper;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[Summary(HD.FN_BLOCK)]
public class FunctionBlock : ActiveKitComponent
{
    [Command]
    [SerializeField]
    protected ActiveKitComponent m_completeAfter;

    [SerializeField]
    [Range(1f, 2f)]
    [Setting("How big relative to the absolute minimum size of the box required to encapsulate the child objects")]
    private float scaleFactor = 1.1f;
    [SerializeField]
    [Setting(TT.IN_COL)]
    private Color boxColor = new Color(1f, 1f, 1f, 0.25f);
    [SerializeField]
    [Setting("Should the box encapsulate just the immediate children.")]
    private bool m_FirstGenerationOnly = false;
    [SerializeField]
    [Setting("")]
    private GizmoDrawFrame m_mode = GizmoDrawFrame.Solid;
    [Setting(TT.ST_GIZMO_HIDE)]
    [SerializeField]
    private bool m_hideGizmos = false;
    [HideInInspector]
    [Ignore]
    private bool lastState;

    protected override GizmoHelper.PartType PartType
    {
        get
        {
            return GizmoHelper.PartType.Block;
        }
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        lastState = !m_hideGizmos;
    }


    protected override void OnDisable()
    {
        base.OnDisable();
        SetGizmoVisibility(false);
    }

    [ExecuteInEditMode]
    protected override void Update()
    {
        base.Update();
        if (lastState != m_hideGizmos)
        {
            SetGizmoVisibility(m_hideGizmos);
        }
    }

    private void SetGizmoVisibility(bool isHidden)
    {
        KitComponent[] bits = GetComponentsInChildren<KitComponent>();
        for (int i = 0; i < bits.Length; i++)
        {
            bits[i].hideGizmos = isHidden;
        }
        lastState = isHidden;
    }

    public override bool DrawSpecialisedGizmos()
    {
        windowDisplayRect = new Rect(transform.position, Vector2.zero);
        Bounds boundary = new Bounds(transform.position, Vector3.zero);
        boundary = EncapsulateChildren(boundary, transform);
        Gizmos.color = boxColor;
        Vector3 offset = transform.position - boundary.center;
        switch (m_mode)
        {
            case GizmoDrawFrame.Solid:
                Gizmos.DrawCube(boundary.center - offset * (scaleFactor - 1f), boundary.size * scaleFactor);
                Color frameColor = boxColor;
                frameColor.a = 1f;
                Gizmos.color = frameColor;
                Gizmos.DrawWireCube(boundary.center - offset * (scaleFactor - 1f), boundary.size * scaleFactor);
                break;
            case GizmoDrawFrame.Wireframe:
                Gizmos.DrawWireCube(boundary.center - offset * (scaleFactor - 1f), boundary.size * scaleFactor);
                break;
            default:
                Debug.LogWarningFormat(WM.MODE_UNSUPPORTED, m_mode.ToString(), GetType().Name, gameObject.name);
                break;

        }
        return true;
    }

    private Bounds EncapsulateChildren(Bounds boundary, Transform transform)
    {
        List<KitComponent> children = new List<KitComponent>(transform.childCount);
        if (m_FirstGenerationOnly)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                children.AddRange(transform.GetChild(i).GetComponents<KitComponent>());
            }
        }
        else
        {
            children.AddRange(GetComponentsInChildren<KitComponent>());
        }

        for (int i = 0; i < children.Count; i++)
        {
            boundary.Encapsulate(children[i].WindowBounds);
        }
        return boundary;
    }
}

