using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RunnerCreator))]
public class RunnerCreatorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Update"))
            UpdateRunner();
        
        if (GUILayout.Button("Clear"))
            Clear();
    }

    private void Clear()
    {
        (target as RunnerCreator).Clear();

    }

    private void UpdateRunner()
    {
        (target as RunnerCreator).UpdateRunner();
    }
}