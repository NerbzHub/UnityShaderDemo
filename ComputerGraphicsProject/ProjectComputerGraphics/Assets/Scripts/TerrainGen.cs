using UnityEngine;

public class TerrainGen : MonoBehaviour
{
    public int depth = 20;
    public int width = 256;
    public int height = 256;
    public float scale = 20f;

    public float offsetX = 100f;
    public float offsetY = 100f;

    private void Start()
    {
        offsetX = Random.Range(0.0f, 9999.0f);
        offsetY = Random.Range(0.0f, 9999.0f);

    }

    private void Update()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);

        offsetX += 0.01f;
        offsetY += 0.01f;
        if (offsetX >= 999999998.0f)
            offsetX = 100f;
        if (offsetY >= 999999998.0f)
            offsetY = 100f;
    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;

        terrainData.size = new Vector3(width, depth, height);

        terrainData.SetHeights(0, 0, GenerateHeights());

        return terrainData;
    }

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

    float CalculateHeight (int x, int y)
    {
        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}
