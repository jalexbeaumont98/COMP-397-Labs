using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class RandomMap : MonoBehaviour
{
    [SerializeField] private int width;
    [SerializeField] private int depth;
    [SerializeField] private float tileScalar = 32;

    [SerializeField] private List<GameObject> prefabTilesList = new List<GameObject>();
    [SerializeField] private Transform mapParent;
    [SerializeField] private Transform startPoint;
    [SerializeField] private GameObject[,] map;
    [SerializeField] private List<List<GameObject>> listMap = new List<List<GameObject>>();


    void Start()
    {
        map = new GameObject[width, depth];
        //BuildRandomMap();

        BuildPerlinNoiseMap();
    }

    private void BuildRandomMap()
    {
        
        for (int row = 0; row < depth; row++)
        {
            List<GameObject> listRow = new List<GameObject>();
            for (int col = 0; col < width; col++)
            {
                if (row == 0 && col == 0) continue;

                Vector3 pos = new Vector3(col * tileScalar, 0f, row * tileScalar);
                GameObject tile = Instantiate(prefabTilesList[Random.Range(0, prefabTilesList.Count)], pos, quaternion.identity, mapParent);
                listRow.Add(tile);
                map[col, row] = tile;
            }
            listMap.Add(listRow);
        }
    }

    private void BuildPerlinNoiseMap()
    {

        float seed = Random.Range(1000, 5000);

        for (int row = 0; row < depth; row++)
        {
            List<GameObject> listRow = new List<GameObject>();
            for (int col = 0; col < width; col++)
            {
                if (row == 0 && col == 0) continue;

                Vector3 pos = new Vector3(col * tileScalar, 0f, row * tileScalar);
                float perlinNoiseValue = GetPerlinNoise(col, row, seed);
                GameObject tile = Instantiate(GenerateTileOnPerlinNoise(perlinNoiseValue), pos, quaternion.identity, mapParent);
                listRow.Add(tile);
                map[col, row] = tile;
            }
            listMap.Add(listRow);
        }
    }

    float GetPerlinNoise(float x, float z, float seed)
    {
        
        float xCoord = (x + seed) * (width / tileScalar);
        float zCoord = (z + seed) * (width / tileScalar);

        return Mathf.PerlinNoise(xCoord, zCoord);
    }

    GameObject GenerateTileOnPerlinNoise(float noiseValue)
    {
        switch (noiseValue)
        {
            case <= 0.2f:
                return prefabTilesList[0]; //water
            case <= 0.4f:
                return prefabTilesList[1]; //grass
            case <= 0.6f:
                return prefabTilesList[2]; //road
            case <= 0.8f:
                return prefabTilesList[3]; //ground
            case <= 1f: 
                return prefabTilesList[4]; //lava

            default: return prefabTilesList[1];
        }
    }
}
