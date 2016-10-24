using UnityEngine;
using System.Collections;

public static class TerrainGenerator {
    public static void GenerateTerrainMesh(Terrain terrainMesh, float[,] heightmap, bool meldNoise) {
        // TODO: Fix terrain resize issues (the values of 128, 256, 512 work well but a large number of other values don't)
        TerrainData td = terrainMesh.terrainData;
        int dimension = heightmap.GetLength(0);

        // Get the existing map data
        float[,] currentMap = td.GetHeights(0, 0, dimension, dimension);

        td.baseMapResolution = heightmap.GetLength(0);
        td.heightmapResolution = heightmap.GetLength(0);
        int pps = 5; // pixels-per-sample
        td.size = new Vector3((float)heightmap.GetLength(0) * pps, 255f, (float)heightmap.GetLength(1) * pps);

        // Check if map is blank
        bool blankMap = true;
        for (int x = 0; x < dimension; x++) {
            for (int y = 0; y < dimension; y++) {
                if (currentMap[x, y] != 0) {
                    blankMap = false;
                    break;
                }              
            }
        }

        if (meldNoise & !blankMap) { // Combinational Noise Code
            float[,] newHeights = new float[dimension, dimension];
            for (int x = 0; x < dimension; x++) {
                for (int y = 0; y < dimension; y++) {
                    newHeights[x, y] = (heightmap[x, y] + currentMap[x, y]) / 2;
                }
            }
            td.SetHeights(0, 0, newHeights); // Set the terrain mesh heights
        } else { // Do not combine noise...
            td.SetHeights(0, 0, heightmap); // Set the terrain mesh heights
        }

        terrainMesh.Flush();
    }
}
