using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
/// <summary>
/// Помогает орентирвоаться в сценах
/// </summary>
public class SceneInspector : EditorWindow
{
    private List<SceneAsset> _scenes = new List<SceneAsset>();

    [MenuItem("UnityDev/SceneInspector/Open Window")]
    private static void Init() => EditorWindow.GetWindow(typeof(SceneInspector));

    private void OnGUI()
    {
        GUILayout.Label("Scenes to include in build:", EditorStyles.boldLabel);
        for (int i = 0; i < _scenes.Count; ++i)
        {
            _scenes[i] = (SceneAsset)EditorGUILayout.ObjectField(_scenes[i], typeof(SceneAsset), false);
        }
        if (GUILayout.Button("Add"))
        {
            _scenes.Add(null);
        }

        GUILayout.Space(8);

        if (GUILayout.Button("Apply To Build Settings"))
        {
            SetEditorBuildSettingsScenes();
        }
    }

    public void SetEditorBuildSettingsScenes()
    {
        List<EditorBuildSettingsScene> editorBuildSettingsScenes = new List<EditorBuildSettingsScene>();
        foreach (var sceneAsset in _scenes)
        {
            string scenePath = AssetDatabase.GetAssetPath(sceneAsset);
            if (!string.IsNullOrEmpty(scenePath))
                editorBuildSettingsScenes.Add(new EditorBuildSettingsScene(scenePath, true));
        }

        EditorBuildSettings.scenes = editorBuildSettingsScenes.ToArray();
    }
}
#endif