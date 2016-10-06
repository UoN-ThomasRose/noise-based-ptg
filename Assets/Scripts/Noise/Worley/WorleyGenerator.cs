using UnityEngine;
using System.Collections;

public class WorleyGenerator : MonoBehaviour {

    public int seed;
    [Range(128, 512)] public int dimension;
    [Range(1, 1)] public int n;
    [Range(5, 20)] public int nFeatures;
    public bool autoUpdate;
    Terrain terrainMesh;

    public void GenerateMap() {
        terrainMesh = GetComponent<Terrain>();
        float[,] noiseMap = Worley.GenerateNoiseMap(seed, dimension, n, nFeatures);
        TerrainGenerator.GenerateTerrainMesh(terrainMesh, noiseMap, true);
    }

    void Update() {
        //GenerateMap();
    }
}
