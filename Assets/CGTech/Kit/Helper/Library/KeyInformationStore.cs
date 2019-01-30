using UnityEngine;
using System.Collections;

public class KeyInformationStore : MonoBehaviour
{
    [SerializeField]
    private int m_MajorBuildNumber = 2;

    public int MajorBuildNumber
    {
        get
        {
            return m_MajorBuildNumber;
        }

        set
        {
            m_MajorBuildNumber = value;
        }
    }
}
