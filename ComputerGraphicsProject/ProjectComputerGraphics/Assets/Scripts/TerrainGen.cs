/*
    TerrainGen.cs
    
    Purpose: To procedurally generate terrain. From 
            there, to have it constantly animating, 
            creating waves.

    @author Nathan Nette
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGen : MonoBehaviour
{
    // Depth is how high the unity terrain can go.
    public int depth = 20;

    // Width of the unity terrain.
    public int width = 256;

    // Height of the unity terrain.
    public int height = 256;

    // Scale of the unity terrain.
    public float scale = 20f;

    // Changing the offset allows for wave-like movement.
    public float offsetX = 100f;
    public float offsetY = 100f;

    // Use this for initialization.
    private void Start()
    {
        // Let random.range choose a float value between 0 and 10000 for
        // both the x and the y.
        offsetX = Random.Range(0.0f, 10000.0f);
        offsetY = Random.Range(0.0f, 10000.0f);
    }

    // Update is called once per frame.
    private void Update()
    {
        // Cache the terrain data. The reason that this is doing this
        // every frame is because it allows the terrain's information 
        // to be updated every frame, to allow the wave effect.
        Terrain terrain = GetComponent<Terrain>();

        // Generate the terrain with any new values.
        terrain.terrainData = GenerateTerrain(terrain.terrainData);

        // Add a small amount to the offset x and y to make the
        // terrain constantly move.
        offsetX += 0.01f;
        offsetY += 0.01f;

        // If the offset goes above 999999 then set both x and y to 100.
        if (offsetX >= 999999.0f)
            offsetX = 100f;
        if (offsetY >= 999999.0f)
            offsetY = 100f;
    }

    /*
        This function re-generates the terrain.

            @param1 terrainData stores majority of the necessary data
                    to be sent into the unity terrain engine to create 
                    a new one.
     */
    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        // Set the hightMapResolution to the width + 1.
        terrainData.heightmapResolution = width + 1;

        // Put the width, depth and height into a vec3 and allocate it
        // in the terrainData size.
        terrainData.size = new Vector3(width, depth, height);

        // Set the heights of the terrain.
        terrainData.SetHeights(0, 0, GenerateHeights());

        return terrainData;
    }

    /*
        Generate Heights basically stores a grid of points
            on the x and y and use those for the height of
            the terrain. 
            It's like projecting a 2D grid on the side of
            the terrain to draw the various heights.
     */
    float[,] GenerateHeights()
    {

        float[,] heights = new float[width, height];
        for(int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
            }
        }

        return heights;
    }

    /*
        Calculate Height calculates the x and y of the grid
            mentioned in generate heights.
            It uses xORy / width * scale + offsetxORy;

        It then utilizes the Mathf function perlin noise to
            add some randomness to it.
    */
    float CalculateHeight (int x, int y)
    {
        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}
