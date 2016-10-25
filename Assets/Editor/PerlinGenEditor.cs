using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof (PerlinGenerator))] 
public class PerlinGenEditor : Editor {

    public override void OnInspectorGUI() {
        PerlinGenerator mapGen = (PerlinGenerator)target;

        //DrawDefaultInspector();

        /* GENERAL SETTINGS */
        EditorGUILayout.LabelField("General Settings", EditorStyles.boldLabel);
        mapGen.seed = EditorGUILayout.IntField("Seed", mapGen.seed);
        mapGen.usingSeed = EditorGUILayout.Toggle("Using Seed?", mapGen.usingSeed);
        mapGen.dimension = EditorGUILayout.IntSlider("Dimension", mapGen.dimension, 128, 512);
        mapGen.noiseScale = EditorGUILayout.Slider("Noise Scale", mapGen.noiseScale, 2f, 100f);
        mapGen.octaves = EditorGUILayout.IntSlider("Octaves", mapGen.octaves, 1, 10);
        mapGen.persistence = EditorGUILayout.Slider("Persistence", mapGen.persistence, 0.1f, 1f);
        mapGen.lacunarity = EditorGUILayout.Slider("Lacunarity", mapGen.lacunarity, 1.5f, 3f);
        mapGen.offset = EditorGUILayout.Vector2Field("Offset", /*new Vector2(0.0f, 0.0f),*/ mapGen.offset);

        /* AUTO UPDATE */
        // TODO: Fix this in the new custom inspector implementation
        //EditorGUILayout.LabelField("Auto Update", EditorStyles.boldLabel);
        //mapGen.autoUpdate = EditorGUILayout.Toggle(mapGen.autoUpdate);
        //EditorGUILayout.HelpBox("Turn off auto update when attmepting to add multiple generations of noise.", MessageType.Warning);

        ///* ANIMATED NOISE */
        EditorGUILayout.LabelField("Animated Noise", EditorStyles.boldLabel);
        mapGen.movingNoise = EditorGUILayout.Toggle("Moving Noise?", mapGen.movingNoise);
        mapGen.displacementVector = EditorGUILayout.Vector2Field("Displacement Vector", /*new Vector2(0.0f, 0.0f),*/ mapGen.displacementVector);

        /* BUTTONS */
        EditorGUILayout.LabelField("Action Buttons", EditorStyles.boldLabel);
        if(GUILayout.Button("Generate")) {
            mapGen.GenerateMap();
        }

        if (GUILayout.Button("Flatten")) {
            mapGen.flattenMap();
        }

        // Auto Update Functionality
        if (mapGen.autoUpdate) {
            mapGen.flattenMap();
            mapGen.GenerateMap();
        }
    }
}
