using UnityEngine;
using System.Collections;

public static class DiamondSquare {

    public static float [,] GenerateNoiseMap(int seed, int dimension, int roughness) {

        // Ensure the terrain dimensions conform to 2n + 1
        if (dimension % 2 == 0)
            dimension++;

        // Generate the empty map
        float[,] map = new float[dimension, dimension];

        // Decrement the dimension for indexing purposes
        dimension--;

        //TODO: Add the main algorithm
        System.Random prng = new System.Random(seed);

        // Set initial corner values
        map[0, 0] = prng.Next(0, 255); // bottom left
        map[0, dimension] = prng.Next(0, 255); // top left
        map[dimension, 0] = prng.Next(0, 255); // bottom right
        map[dimension, dimension] = prng.Next(0, 255); // top right

        SubDivide(ref map, ref prng, dimension, ref roughness);
        
        return null;
    }

    private static void SubDivide(ref float[,] map, ref System.Random prng, int dimension, ref int roughness) {
        int half = (int) Mathf.Floor(dimension / 2); //TODO: Keep and eye on this and make sure it behaves as intended.
        if (half < 1) return; // if subdivision is no longer possible... stop!

        SubDivide(ref map, ref prng, half, ref roughness);
    }

}
