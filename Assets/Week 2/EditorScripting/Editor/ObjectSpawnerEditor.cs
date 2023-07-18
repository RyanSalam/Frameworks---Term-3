using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

[CustomEditor(typeof(ObjectSpawner))]
public class ObjectSpawnerEditor : Editor
{
    private static int count = 5;

    public override void OnInspectorGUI()
    {
        ObjectSpawner spawner = target as ObjectSpawner;

        count = EditorGUILayout.IntSlider("Spawn Count", count, 0, 15);
        if (GUILayout.Button("Spawn Objects"))
        {
            spawner.SpawnObstacle(count);
        }

        base.OnInspectorGUI();
    }

    private void OnSceneGUI()
    {
            
    }
}
