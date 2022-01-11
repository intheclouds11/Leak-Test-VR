using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HeadMountedTrigger))]
// [CanEditMultipleObjects]

public class HeadMountedTriggerEditor : Editor
{
    private SerializedProperty HMDTransform;
    private SerializedProperty faceOffset;
    private SerializedProperty playerControlsVR;
    private SerializedProperty procedureText;
    private SerializedProperty fireworks;


    private void OnEnable()
    {
        HMDTransform = serializedObject.FindProperty("HMDTransform");
        faceOffset = serializedObject.FindProperty("faceOffset");
        playerControlsVR = serializedObject.FindProperty("playerControlsVR");
        procedureText = serializedObject.FindProperty("procedureText");
        fireworks = serializedObject.FindProperty("fireworks");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(HMDTransform);
        EditorGUILayout.PropertyField(faceOffset);
        EditorGUILayout.PropertyField(playerControlsVR);
        EditorGUILayout.PropertyField(procedureText);
        EditorGUILayout.PropertyField(fireworks);
        serializedObject.ApplyModifiedProperties();
    }
}
