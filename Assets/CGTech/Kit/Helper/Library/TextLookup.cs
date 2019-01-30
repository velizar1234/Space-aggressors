using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;

[ExecuteInEditMode]
public class TextLookup : MonoBehaviour
{
    private static TextLookup s_instance = null;
    [SerializeField]
    private List<TextDefinition> m_dictionary = new List<TextDefinition>();
    private bool m_isDirty = false;
    public static TextLookup Instance
    {
        get
        {
            return s_instance;
        }

        private set
        {
            s_instance = value;
        }
    }

    private void Awake()
    {
        TextLookup existingKV = FindObjectOfType<TextLookup>();
        if (existingKV != null && existingKV != this)
        {
            DestroyImmediate(this.gameObject);
        }
        LoadDictionary();
            
    }

    private void LoadDictionary()
    {
        if (!m_isDirty)
        {
            m_dictionary.Clear();
            TextAsset t = Resources.Load<TextAsset>("Text/localization");
            string[] lines = t.text.Split(new char[] { '{' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < lines.Length; i++)
            {
                TextDefinition td = JsonUtility.FromJson<TextDefinition>("{" + lines[i]);
                m_dictionary.Add(td);
               // Debug.Log(td.code + " " + td.text);
            }
        }
    }

    private void SaveDictionary()
    {
        string path = "Assets/Resources/Text/localization.json";

        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, false);
        string text = "";
        for (int i = 0; i < m_dictionary.Count; i++)
        {
            text = text + JsonUtility.ToJson(m_dictionary[i]) + "\r\n";
        }
        writer.Write(text);
        writer.Close();
    }

    public static string GetText(string code)
    {
        CheckExists();
        return s_instance.pGetText(code);
    }

    private static void CheckExists()
    {
        if (s_instance == null)
        {
            TextLookup[] duplicates = FindObjectsOfType<TextLookup>();
            if (duplicates.Length == 0)
            { 
            GameObject gob = new GameObject();
            s_instance = gob.AddComponent<TextLookup>();
                gob.name = "Text Lookup";
            }
            else
            {
                s_instance = duplicates[0];
            }
            
        }
    }

    private string pGetText(string code)
    {
        TextDefinition def = m_dictionary.Find(t => t.code == code);
        if (def != null)
        {
            return def.text;
        }
        else
        {
            m_isDirty = true;
            def = new TextDefinition();
            def.code = code;
            def.text = code;
            m_dictionary.Add(def);
            return code;
        }

    }

    private void OnDisable()
    {
        if (m_isDirty)
        {
            SaveDictionary();
        }
        //s_instance = null;
    }

}
