using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using System.Collections;
using Object = UnityEngine.Object;

public class EditorUtil
{
    private static EditorWindow _mouseOverWindow;

    [MenuItem("Stuff/Toggle Lock &q")]
    static void ToggleInspectorLock()
    {
        if (_mouseOverWindow == null)
        {
            if (!EditorPrefs.HasKey("LockableInspectorIndex"))
                EditorPrefs.SetInt("LockableInspectorIndex", 0);
            int i = EditorPrefs.GetInt("LockableInspectorIndex");

            Type type = Assembly.GetAssembly(typeof(Editor)).GetType("UnityEditor.InspectorWindow");
            Object[] findObjectsOfTypeAll = Resources.FindObjectsOfTypeAll(type);
            _mouseOverWindow = (EditorWindow)findObjectsOfTypeAll[i];
        }

        if (_mouseOverWindow != null && _mouseOverWindow.GetType().Name == "InspectorWindow")
        {
            Type type = Assembly.GetAssembly(typeof(Editor)).GetType("UnityEditor.InspectorWindow");
            PropertyInfo propertyInfo = type.GetProperty("isLocked");
            bool value = (bool)propertyInfo.GetValue(_mouseOverWindow, null);
            propertyInfo.SetValue(_mouseOverWindow, !value, null);
            _mouseOverWindow.Repaint();
        }
    }

    [MenuItem("Stuff/TogglePlay &w")]
    static void TogglePlay()
    {
        if (EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = false;
        }
        else
        {
            EditorApplication.isPlaying = true;
        }
    }

    [MenuItem("Stuff/ClearConsole &c")]
    static void ClearConsole()
    {
        var assembly = Assembly.GetAssembly(typeof(SceneView));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }
}

