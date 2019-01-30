﻿
using System;
using System.Reflection;
#if UNITY_EDITOR
using UnityEditor;
#endif 
using UnityEngine;
/// <summary>
/// Helper class for drawing in-built Unity icons for objects.
/// </summary>
/// <remarks> Thundernerd, 2014, IconManager [online] https://forum.unity3d.com/threads/editor-script-to-set-icons-impossible.187975/ Accessed 10/07/2017</remarks>
public class IconManager
{

    public enum LabelIcon
    {
        None = -1,
        Gray = 0,
        Blue,
        Teal,
        Green,
        Yellow,
        Orange,
        Red,
        Purple
    }

    public enum DotIcon
    {
        CircleGray = 0,
        CircleBlue,
        CircleTeal,
        CircleGreen,
        CircleYellow,
        CircleOrange,
        CircleRed,
        CirclePurple,
        DiamondGray,
        DiamondBlue,
        DiamondTeal,
        DiamondGreen,
        DiamondYellow,
        DiamondOrange,
        DiamondRed,
        DiamondPurple
    }

    private static GUIContent[] labelIcons;
    private static GUIContent[] largeIcons;

    public static void SetIcon(GameObject gObj, LabelIcon icon)
    {
#if UNITY_EDITOR
        if (labelIcons == null)
        {
            labelIcons = GetTextures("sv_label_", string.Empty, 0, 8);
        }
        if ((int)icon >= 0)
            SetIcon(gObj, labelIcons[(int)icon].image as Texture2D);
        else
            SetIcon(gObj, null as Texture2D);
#endif
    }

    public static void SetIcon(GameObject gObj, DotIcon icon)
    {
        if (largeIcons == null)
        {
            largeIcons = GetTextures("sv_icon_dot", "_pix16_gizmo", 0, 16);
        }

        SetIcon(gObj, largeIcons[(int)icon].image as Texture2D);
    }

    private static void SetIcon(GameObject gObj, Texture2D texture)
    {
#if UNITY_EDITOR
        var ty = typeof(EditorGUIUtility);
        var mi = ty.GetMethod("SetIconForObject", BindingFlags.NonPublic | BindingFlags.Static);
        mi.Invoke(null, new object[] { gObj, texture });
#endif
    }

    private static GUIContent[] GetTextures(string baseName, string postFix, int startIndex, int count)
    {
        GUIContent[] guiContentArray = new GUIContent[count];
#if UNITY_EDITOR
        var t = typeof(EditorGUIUtility);
        var mi = t.GetMethod("IconContent", BindingFlags.Public | BindingFlags.Static, null, new Type[] { typeof(string) }, null);

        for (int index = 0; index < count; ++index)
        {
            guiContentArray[index] = mi.Invoke(null, new object[] { baseName + (object)(startIndex + index) + postFix }) as GUIContent;
        }
#endif
        return guiContentArray;
    }
}
