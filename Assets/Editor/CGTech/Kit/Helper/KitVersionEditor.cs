using Anglia.CGTech.CKit.Helper.Library;
using UnityEditor;
namespace Anglia.CGTech.KitEditor.Helper
{
    [CustomEditor(typeof(KitVersion))]
    [CanEditMultipleObjects]
    public class KitVersionEditor : UnityEditor.Editor
    {

        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField("Version:" + KitSettings.KIT_VERSION);// + "." + KitSettings.BuildNumber);
        }
    }



}
