using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(DiamondSquareGenerator))]
public class DiamondSquareGenEditor : Editor {


    public override void OnInspectorGUI() {
        DiamondSquareGenerator mapGen = (DiamondSquareGenerator)target;

        if (DrawDefaultInspector())
            if (mapGen.autoUpdate)
                mapGen.GenerateMap();

        if (GUILayout.Button("Generate")) {
            mapGen.GenerateMap();
        }

        if (GUILayout.Button("Flatten")) {
            mapGen.flattenMap();
        }
    }
}
