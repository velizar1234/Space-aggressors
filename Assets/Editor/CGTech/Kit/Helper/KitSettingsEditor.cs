using Anglia.CGTech.CKit.Helper.Library;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace Anglia.CGTech.CKit.Helper
{


    [CustomEditor(typeof(KitSettings))]
    [CanEditMultipleObjects]
    public class KitSettingsEditor : UnityEditor.Editor
    {

        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField("Grid Size: " + KitSettings.GridSize);
            EditorGUILayout.LabelField("Lateral Spread: " + KitSettings.ConnectorLateralSpread);
            EditorGUILayout.LabelField("Minimum Font Size: " + KitSettings.MinimumFontSize);
            EditorGUILayout.LabelField("Default Font Size: " + KitSettings.DefaultFontSize);
            EditorGUILayout.LabelField("Maximum Font Size: " + KitSettings.MaximumFontSize);
            EditorGUILayout.LabelField("View Distance: " + KitSettings.ViewDistance);
            //This works: KitSettings.ConnectorLateralSpread = EditorGUILayout.FloatField(KitSettings.ConnectorLateralSpread);
        }

        //[PostProcessBuild(0)]
        //public static  void IncrementBuildNumber(BuildTarget bt, string s)
        //{
        //    KitSettings.BuildNumber += 1;
        //    Debug.Log("BuildNumber now " + KitSettings.BuildNumber);
        //    KitSettings.Singleton.prefab.MajorBuildNumber += 1; 

        //}
        
    }
}
