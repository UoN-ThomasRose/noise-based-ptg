using UnityEngine;
using System.Collections;

public class PerlinGenerator : MonoBehaviour {

    public int seed;
    public bool usingSeed;
    [Range(128, 512)] public int dimension;
    [Range(2f,100f)] public float noiseScale;
    [Range(1,10)] public int octaves;
    [Range(0.1f,1f)] public float persistence;
    [Range(1.5f,3f)] public float lacunarity;
    public Vector2 offset;
    public bool autoUpdate;
    public bool movingNoise;
    public Vector2 displacementVector;
    Terrain terrainMesh;

    public void GenerateMap() {
        terrainMesh = GetComponent<Terrain>();
        if (usingSeed) {
            float[,] noiseMap = Perlin.GenerateNoiseMap(seed, dimension, noiseScale, octaves, persistence, lacunarity, offset);
            TerrainGenerator.GenerateTerrainMesh(terrainMesh, noiseMap, true);
        } else {
            float[,] noiseMap = Perlin.GenerateNoiseMap(0, dimension, noiseScale, octaves, persistence, lacunarity, offset);
            TerrainGenerator.GenerateTerrainMesh(terrainMesh, noiseMap, true);
        }    
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

    void Start() {
        if(movingNoise)
            InvokeRepeating("moveNoise", 0, 0.1f);
    }

    void moveNoise() {
        // Why is this reversed???
        offset.x += displacementVector.y;
        offset.y += displacementVector.x;
        GenerateMap();
    }

    [ExecuteInEditMode]
    void OnValidate() {
        offset.x = Mathf.Clamp(offset.x, -1000, 1000);
        offset.y = Mathf.Clamp(offset.y, -1000, 1000);
    }
}
