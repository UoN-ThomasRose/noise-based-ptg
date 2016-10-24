using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(WorleyGenerator))]
public class WorleyGenEditor : Editor {

    public override void OnInspectorGUI() {
        WorleyGenerator mapGen = (WorleyGenerator)target;

        if (DrawDefaultInspector()) {
            if (mapGen.autoUpdate) {
                mapGen.flattenMap();
                mapGen.GenerateMap();
            }
        }

        if (GUILayout.Button("Generate")) {
            mapGen.GenerateMap();
        }

        if (GUILayout.Button("Flatten")) {
            mapGen.flattenMap();
        }
    }
}
