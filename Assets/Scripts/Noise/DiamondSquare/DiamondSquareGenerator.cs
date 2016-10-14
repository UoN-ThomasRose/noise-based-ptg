using UnityEngine;
using System.Collections;

public class DiamondSquareGenerator : MonoBehaviour {

    public int seed;
    [Range(128, 512)] public int dimension;
    [Range(0, 100)] public int roughness;
    public bool autoUpdate;
    Terrain terrainMesh;

    public void GenerateMap() {
        terrainMesh = GetComponent<Terrain>();
        float[,] noiseMap = DiamondSquare.GenerateNoiseMap(seed, dimension, roughness);
        TerrainGenerator.GenerateTerrainMesh(terrainMesh, noiseMap, true);
    }

    public void flattenMap() {
        terrainMesh = GetComponent<Terrain>();
        float[,] map = new float[dimension, dimension];

        // Flatten the map - set all height values to 0
        for (int x = 0; x < dimension; x++)
            for (int y = 0; y < dimension; y++)
                map[x, y] = 0;

        TerrainGenerator.GenerateTerrainMesh(terrainMesh, map, false);
    }
}
