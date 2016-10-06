﻿using UnityEngine;
using System.Collections;

public static class Perlin {

    // Single Octave - no seed
	public static float [,] GenerateNoiseMap(int dimension, float scale) {
        float[,] map = new float[dimension, dimension];

        if (scale <= 0)
            scale = 0.0001f;

        for (int x = 0; x < dimension; x++) {
            for (int y = 0; y < dimension; y++) {
                float sampleX = x / scale;
                float sampleY = y / scale;
                float perlinValue = Mathf.PerlinNoise(sampleX, sampleY);
                map[x, y] = perlinValue;
            }
        }

        return map;
    }

    // Multiple Octaves - no seed
    public static float[,] GenerateNoiseMap(int dimension, float scale, int octaves, float persistence, float lacunarity) {
        float[,] map = new float[dimension, dimension];

        if (scale <= 0)
            scale = 0.0001f;

        // For Normalisation
        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;

        // Perlin Noise Generation
        for (int x = 0; x < dimension; x++) {
            for (int y = 0; y < dimension; y++) {

                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;

                for(int i = 0; i < octaves; i++) {
                    float sampleX = x / scale * frequency;
                    float sampleY = y / scale * frequency;

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    noiseHeight += perlinValue * amplitude;

                    amplitude *= persistence;
                    frequency *= lacunarity;
                }

                if (noiseHeight > maxNoiseHeight)
                    maxNoiseHeight = noiseHeight;
                else if (noiseHeight < minNoiseHeight)
                    minNoiseHeight = noiseHeight;

                map[x, y] = noiseHeight;
            }
        }

        // Normalise
        for (int x = 0; x < dimension; x++) {
            for (int y = 0; y < dimension; y++) {
                map[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, map[x, y]);
            }
        }

        return map;
    }

    // Multiple Octaves - with seed
    public static float[,] GenerateNoiseMap(int seed, int dimension, float scale, int octaves, float persistence, float lacunarity, Vector2 offset) {
        float[,] map = new float[dimension, dimension];

        // Generate the offsets for each octave
        System.Random prng = new System.Random(seed);
        Vector2[] octaveOffets = new Vector2[octaves];
        for(int i = 0; i < octaves; i++) {
            float offsetX = prng.Next(-100000, 100000) + offset.x;
            float offsetY = prng.Next(-100000, 100000) + offset.y;
            octaveOffets[i] = new Vector2(offsetX, offsetY);
        }

        // Stop division by 0
        if (scale <= 0)
            scale = 0.0001f;

        // For Normalisation
        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;

        // Perlin Noise Generation
        for (int x = 0; x < dimension; x++) {
            for (int y = 0; y < dimension; y++) {

                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;

                for (int i = 0; i < octaves; i++) {
                    float sampleX = x / scale * frequency + octaveOffets[i].x;
                    float sampleY = y / scale * frequency + octaveOffets[i].y;

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    noiseHeight += perlinValue * amplitude;

                    amplitude *= persistence;
                    frequency *= lacunarity;
                }

                if (noiseHeight > maxNoiseHeight)
                    maxNoiseHeight = noiseHeight;
                else if (noiseHeight < minNoiseHeight)
                    minNoiseHeight = noiseHeight;

                map[x, y] = noiseHeight;
            }
        }

        // Normalise
        for (int x = 0; x < dimension; x++) {
            for (int y = 0; y < dimension; y++) {
                map[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, map[x, y]);
            }
        }

        return map;
    }
}