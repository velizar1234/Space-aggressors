using UnityEngine;

namespace Anglia.CGTech.CKit.Helper.Library
{

    [ExecuteInEditMode]
    public class KitVersion : MonoBehaviour
    {



        [SerializeField]
        public string ver;
        public Rect location = new Rect(0, 0, 200, 25);
        private static KitVersion m_singleton = null;


        private void Awake()
        {

            KitVersion existingKV = FindObjectOfType<KitVersion>();
            if (existingKV != this)
            {
                DestroyImmediate(this);
            }
        }

        void OnDisable()
        {
            this.enabled = true;
            //gameObject.SetActive(true);
        }


        public static void CreateKitVersion()
        {
            if (m_singleton == null)
            {
                KitVersion existingKV = FindObjectOfType<KitVersion>();
                GameObject gob;
                if (existingKV == null)
                {
                    gob = new GameObject();
                    gob.name = "Kit Helper";
                    m_singleton = gob.AddComponent<KitVersion>();
                    gob.AddComponent<KitSettings>().OnEnable();
                }

            }
        }

        void OnGUI()
        {
            GUIContent content = new GUIContent("Construction Kit Version: " + KitSettings.KIT_VERSION);
            location.y = Screen.height - location.height;
            GUI.Label(location, content);
        }
    }
}