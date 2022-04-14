using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using Object = UnityEngine.Object;

[InitializeOnLoad]
public class EditorUtils
{
    static EditorUtils()
    {
        EditorSceneManager.sceneDirtied += (scene) =>
        {
            EditorSceneManager.SaveScene(scene);
        };
    }

    static List<Type> _windowHistory = new List<Type>();
    private static EditorWindow _mouseOverWindow;

    [MenuItem("Util/Toggle Lock &q")]
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

    [MenuItem("Util/TogglePlayerPlay &w")]
    static void TogglePlayerPlay()
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

    [MenuItem("Util/TogglePlayerPause #&w")]
    static void TogglePlayerPause()
    {
        if (EditorApplication.isPaused)
        {
            EditorApplication.isPaused = false;
        }
        else
        {
            EditorApplication.isPaused = true;
        }
    }

    [MenuItem("Util/PlayerStep &.")]
    static void PlayerStep()
    {
        EditorApplication.Step();
    }

    [MenuItem("Util/ClearConsole &c")]
    static void ClearConsole()
    {
        var assembly = Assembly.GetAssembly(typeof(SceneView));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }

    [MenuItem("Util/CloseWindow %w")]
    static void CloseWindow()
    {
        EditorWindow window = EditorWindow.focusedWindow;
        if (window != null)
        {
            _windowHistory.Add(window.GetType());
            window.Close();
        }
    }

    [MenuItem("Util/RecoveryWindow %#t")]
    static void RecoveryWindow()
    {
        if (_windowHistory.Count > 0)
        {
            Type window = _windowHistory[_windowHistory.Count - 1];
            _windowHistory.RemoveAt(_windowHistory.Count - 1);
            EditorWindow newWindow = EditorWindow.GetWindow(window);
            newWindow.Show();
            newWindow.ShowNotification(new GUIContent($"WindowRecovered"));
        }
    }
}
