using UnityEngine;
//using System;
using System.Collections;

public static class Worley {

    // Single Octave - no seed
    public static float[,] GenerateNoiseMap(int seed, int dimension, int n, int nFeatures) {

        float[,] map = new float[dimension, dimension];

        // Generate the feature points
        Vector2[] featurePoints = new Vector2[nFeatures];
        for(int i = 0; i < featurePoints.Length; i++) {
            int x = (int) Mathf.Round(Random.Range(0, dimension));
            int y = (int) Mathf.Round(Random.Range(0, dimension));
            featurePoints[i] = new Vector2(x, y);
        }

        // Calculate the value for each pixel
        //  - get the feature point distances
        //  - sort the feature points into order of closest to furthest
        //  - assign the value

        // For each pixel...
        for (int x = 0; x < dimension; x++) {
            for (int y = 0; y < dimension; y++) {

                int nTemp = n - 1;
                Vector2 currentPoint = new Vector2(x, y);

                // Get the feature point distances and calculate the value from the nth feature
                int[] distances = new int[featurePoints.Length]; 
                for (int i = 0; i < distances.Length; i++) {

                    distances[i] = euclideanDistance(currentPoint, featurePoints[i]);

                    if (i == 0) map[x, y] = distances[i]; // If distance is the first one being checked, assign it.
                    else if (distances[i] <= map[x,y]) { // For subsequent distance values... check if distance value is lower than pixel value
                        if (nTemp == 0) {
                            map[x, y] = distances[i];
                        } else {
                            nTemp--;
                        }
                    }
                }
            }
        }

        // Keep the values bounded - TODO: Review this part
        for (int x = 0; x < dimension; x++) {
            for (int y = 0; y < dimension; y++) {
                map[x, y] = (map[x, y] / 100);
            }
        }

        return map;
    }

    private static Vector2 randomPoint(System.Random prng, int seed, int min, int max) {
        int x = prng.Next(min, max);
        int y = prng.Next(min, max);
        return new Vector2(x, y);
    }

    private static int euclideanDistance(Vector2 p1, Vector2 p2) {
        float distance = Mathf.Sqrt(Mathf.Pow((p1.x - p2.x), 2f) + Mathf.Pow((p1.y - p2.y), 2f));
        return (int)distance;
    }
}

public static class InverseWorley {

    // Single Octave - no seed
    public static float[,] GenerateNoiseMap(int seed, int dimension, int n, int nFeatures) {

        float[,] map = new float[dimension, dimension];

        // Generate the feature points
        Vector2[] featurePoints = new Vector2[nFeatures];
        for (int i = 0; i < featurePoints.Length; i++) {
            int x = (int)Mathf.Round(Random.Range(0, dimension));
            int y = (int)Mathf.Round(Random.Range(0, dimension));
            featurePoints[i] = new Vector2(x, y);
        }

        // Calculate the value for each pixel
        //  - get the feature point distances
        //  - sort the feature points into order of closest to furthest
        //  - assign the value

        // For each pixel...
        for (int x = 0; x < dimension; x++) {
            for (int y = 0; y < dimension; y++) {

                int nTemp = n - 1;
                Vector2 currentPoint = new Vector2(x, y);

                // Get the feature point distances and calculate the value from the nth feature
                int[] distances = new int[featurePoints.Length];
                for (int i = 0; i < distances.Length; i++) {

                    distances[i] = euclideanDistance(currentPoint, featurePoints[i]);

                    if (i == 0) map[x, y] = distances[i]; // If distance is the first one being checked, assign it.
                    else if (distances[i] >= map[x, y]) { // For subsequent distance values... check if distance value is lower than pixel value
                        if (nTemp == 0) {
                            map[x, y] = -distances[i];
                        } else {
                            nTemp--;
                        }
                    }
                }
            }
        }

        // Keep the values bounded - TODO: Review this part
        for (int x = 0; x < dimension; x++) {
            for (int y = 0; y < dimension; y++) {
                map[x, y] = (map[x, y] / 100);
            }
        }

        return map;
    }

    private static Vector2 randomPoint(System.Random prng, int seed, int min, int max) {
        int x = prng.Next(min, max);
        int y = prng.Next(min, max);
        return new Vector2(x, y);
    }

    private static int euclideanDistance(Vector2 p1, Vector2 p2) {
        float distance = Mathf.Sqrt(Mathf.Pow((p1.x - p2.x), 2f) + Mathf.Pow((p1.y - p2.y), 2f));
        return (int)distance;
    }
}
