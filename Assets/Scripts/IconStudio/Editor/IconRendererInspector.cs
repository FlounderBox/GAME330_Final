using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(IconRenderer))]
public class IconRendererInspector : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        IconRenderer myTarget = (IconRenderer)target;

        if (GUILayout.Button("Render Icons"))
        {
            myTarget.TakeScreenshotsOfChildren();
        }
        DrawDefaultInspector();
    }
}
