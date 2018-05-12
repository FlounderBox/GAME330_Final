using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameEventListener))]
public class GameEventListenerEditor : Editor
{

    bool showVoidResponse = true;
    bool showFloatResponse;
    bool showSpriteResponse;

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        GameEventListener myTarget = (GameEventListener)target;

        EditorGUILayout.ObjectField(serializedObject.FindProperty("Event"));
        showVoidResponse = EditorGUILayout.Foldout(showVoidResponse, "Void response");
        if (showVoidResponse)
        {
            SerializedProperty voidEvent = serializedObject.FindProperty("Response");
            EditorGUILayout.PropertyField(voidEvent);
        }

        showFloatResponse = EditorGUILayout.Foldout(showFloatResponse, "Float response");
        if (showFloatResponse)
        {
            SerializedProperty voidEvent = serializedObject.FindProperty("ResponseFloat");
            EditorGUILayout.PropertyField(voidEvent);
        }

        showSpriteResponse = EditorGUILayout.Foldout(showSpriteResponse, "Sprite response");
        if (showSpriteResponse)
        {
            SerializedProperty voidEvent = serializedObject.FindProperty("ResponseSprite");
            EditorGUILayout.PropertyField(voidEvent);
        }
        serializedObject.ApplyModifiedProperties();
    }
}
