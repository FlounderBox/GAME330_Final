using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Item))]
[CanEditMultipleObjects]
public class ItemInspector : Editor {
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        Item myTarget = (Item)target;

        EditorGUILayout.LabelField("Item Score: ", myTarget.Score.ToString());
        //EditorGUILayout.LabelField("EngulfScore: ", myTarget.Score.ToString());

        DrawDefaultInspector();
    }
}