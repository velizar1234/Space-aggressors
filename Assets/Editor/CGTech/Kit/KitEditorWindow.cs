using Anglia.CGTech.CKit.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class KitEditorWindow : EditorWindow {

    [MenuItem("Window/Kit Editor")]

    static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(KitEditorWindow));
        
    }

    


    // Update is called once per frame
    Vector2 m_scrollPos = Vector2.zero;
    void OnGUI()
    {
        GameObject target = Selection.activeGameObject;
        if (target != null)
        {
            KitComponent currentComponent = target.GetComponent<KitComponent>();
            if (currentComponent != null)
            {
                m_scrollPos = EditorGUILayout.BeginScrollView(m_scrollPos);
                GUILayout.BeginArea(currentComponent.windowDisplayRect);
                
                GUILayout.Label("Base Settings", EditorStyles.boldLabel);

                /*bool groupEnabled =*/ EditorGUILayout.BeginToggleGroup("Optional Settings", true);
                /*bool myBool = */ EditorGUILayout.Toggle("Toggle", true);
                /*float myFloat =*/ EditorGUILayout.Slider("Slider", 0.5f, -3, 3);
                EditorGUILayout.EndToggleGroup();
                GUILayout.EndArea();
                EditorGUILayout.EndScrollView();
            }
        }
    }
}
