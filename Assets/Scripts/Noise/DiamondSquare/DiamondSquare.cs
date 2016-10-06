using UnityEngine;
using System.Collections;

public class DiamondSquare : MonoBehaviour {

    private int dimension;
    Terrain myTerrain = Terrain.activeTerrain;

	// Use this for initialization
	void Start () {
        adjustDimensions();
	}

    void adjustDimensions() {
        dimension = myTerrain.terrainData.heightmapHeight;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
