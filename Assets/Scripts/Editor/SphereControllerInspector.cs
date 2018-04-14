using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SphereController))]
public class SphereControllerInspector : Editor {
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        SphereController myTarget = (SphereController)target;

        if (GUILayout.Button("Set Scale From Score"))
        {
            myTarget.UpdateSize();
        }
        //EditorGUILayout.LabelField("Item Score: ", myTarget.Score.ToString());
        //EditorGUILayout.LabelField("EngulfScore: ", myTarget.Score.ToString());

        DrawDefaultInspector();
    }
}
