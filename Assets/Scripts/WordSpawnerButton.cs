using UnityEngine;
using UnityEditor;

#if (UNITY_EDITOR) 
[CustomEditor(typeof(WordSpawner))]
public class WordSpawnerButton : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        //GUI.enabled = Application.isPlaying;

        WordSpawner wordSpawner = target as WordSpawner;

        if (GUILayout.Button("Spawn Word"))
        {
            wordSpawner.SpawnWord();
        }

    }
}
#endif
