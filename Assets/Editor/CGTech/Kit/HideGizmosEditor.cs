using Anglia.CGTech.CKit.Helper;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(HideGizmos))]
[CanEditMultipleObjects]
public class HideGizmosEditor : Editor
{
    //SerializedProperty hideGizmosSetting;

    void OnEnable()
    {
        //foreach (SerializedProperty sp in  serializedObject.GetIterator())
        //{
        //}
        //hideGizmosSetting = serializedObject.FindProperty("m_hideGizmos");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

    }
}

