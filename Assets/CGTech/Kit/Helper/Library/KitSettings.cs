using UnityEngine;
namespace Anglia.CGTech.CKit.Helper.Library
{
    public class KitSettings : MonoBehaviour
    {

        /// <summary>
        /// The current version of the kit.
        /// </summary>
        public const string KIT_VERSION = "2.2.1";
        public const string BUILD_NUM = "BuildNumber";
        private static int s_buildNumber = 1;
        private static float gridSize = 0.5f;
        private static float s_connectorLateralSpread = 0.25f;
        private static int minimumFontSize = 6;
        private static int maximumFontSize = 20;
        private static int defaultFontSize = 12;
        private static float viewDistance = 20;

        private static KitSettings m_singleton = null;

        public static float GridSize
        {
            get
            {
                return gridSize;
            }
            set
            {
                gridSize = value;
                PlayerPrefs.SetFloat(CS.GRID_SIZE, gridSize);
            }
        }

        public static float ConnectorLateralSpread
        {
            get
            {
                return s_connectorLateralSpread;
            }
            set
            {
                s_connectorLateralSpread = value;
                PlayerPrefs.SetFloat(CS.LAT_SPREAD, s_connectorLateralSpread);
            }
        }
        public static int MinimumFontSize
        {
            get
            {
                return minimumFontSize;
            }

            set
            {
                minimumFontSize = value;
            }
        }

        public static int MaximumFontSize
        {
            get
            {
                return maximumFontSize;
            }

            set
            {
                maximumFontSize = value;
            }
        }

        public static int DefaultFontSize
        {
            get
            {
                return defaultFontSize;
            }

            set
            {
                defaultFontSize = value;
            }
        }

        public static float ViewDistance
        {
            get
            {
                return viewDistance;
            }

            set
            {
                viewDistance = value;
            }
        }

        public static int BuildNumber
        {
            get
            {
                return s_buildNumber;
            }

            set
            {
                s_buildNumber = value;
                PlayerPrefs.SetInt(BUILD_NUM, s_buildNumber);
            }
        }

        public static KitSettings Singleton
        {
            get
            {
                return m_singleton;
            }

            set
            {
                m_singleton = value;
            }
        }

        [SerializeField]
        public KeyInformationStore prefab;

        // Use this for initialization
        void Awake()
        {
            if (m_singleton == null)
            {
                m_singleton = this;
                
                gridSize = PlayerPrefs.GetFloat(CS.GRID_SIZE, gridSize);
                s_connectorLateralSpread = PlayerPrefs.GetFloat(CS.LAT_SPREAD, s_connectorLateralSpread);
                //#if DEVELOPMENT
                s_buildNumber = PlayerPrefs.GetInt(BUILD_NUM, s_buildNumber);

                //#endif
            }
            else
            {
                Destroy(this);
            }
        }

        public void OnEnable()
        {
            prefab = Resources.Load<KeyInformationStore>("KVS");
        }
    }
}