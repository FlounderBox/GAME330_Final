using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TerrainGenerator))]
public class TerrainGeneratorInspector : Editor {

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        TerrainGenerator myTarget = (TerrainGenerator)target;

        if (GUILayout.Button("Regenerate terrain"))
        {
            if (myTarget.Prefab != null && myTarget.Heightmap != null && myTarget.Strength != 0)
            myTarget.RegenerateTerrain();
        }

        if (GUILayout.Button("Clear Terrain"))
        {
                myTarget.ClearTerrain();
        }

        DrawDefaultInspector();
    }
}
