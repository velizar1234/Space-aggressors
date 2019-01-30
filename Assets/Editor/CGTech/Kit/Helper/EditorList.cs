using UnityEditor;
using UnityEngine;
/// <summary>
/// Code from/inspired by http://catlikecoding.com/unity/tutorials/editor/custom-list/
/// </summary>
public static class EditorList
{

    public static int Show(SerializedProperty list, int currentSelection)
    {
        string[] options = new string[list.arraySize];
        //EditorGUILayout.PropertyField(list);
        for (int i = 0; i < list.arraySize; i++)
        {
            options[i] = ObjectNames.NicifyVariableName(list.GetArrayElementAtIndex(i).stringValue);
        }
        return EditorGUILayout.Popup(ObjectNames.NicifyVariableName(list.name),currentSelection, options);
    }
}