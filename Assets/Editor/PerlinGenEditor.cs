using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof (PerlinGenerator))] 
public class PerlinGenEditor : Editor {

    public override void OnInspectorGUI() {
        PerlinGenerator mapGen = (PerlinGenerator)target;

        if (DrawDefaultInspector())
            if (mapGen.autoUpdate)
                mapGen.GenerateMap();

        if(GUILayout.Button("Generate")) {
            mapGen.GenerateMap();
        }

        if (GUILayout.Button("Flatten")) {
            mapGen.flattenMap();
        }
    }
}
