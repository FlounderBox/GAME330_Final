using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{

    public GameObject Prefab;
    public Texture2D Heightmap;
    //public int Resolution = 1;
    public float Strength;
    public int Size = 32;

    List<GameObject> terrainPrefabs = new List<GameObject>();

    private void Awake()
    {

    }

    public void ClearTerrain()
    {
        foreach (Transform p in transform.GetComponentsInChildren<Transform>())
        {
            if (p.gameObject != gameObject)
                GameObject.DestroyImmediate(p.gameObject);
        }
        terrainPrefabs.Clear();
    }

    public void RegenerateTerrain()
    {
        ClearTerrain();

        //Get color samples
        int sampleOffset = Heightmap.width / Size;
        Debug.Log(sampleOffset);

        //Width
        for (int x = 0; x < Size; x++)
        {
            //Height
            for (int y = 0; y < Size; y++)
            {

                float xOffset;
                if (y % 2 == 0)
                    xOffset = (Mathf.Sqrt(3) * 5f) / 2;
                else
                    xOffset = 0;

                Debug.Log(2f * 5f * 3f / 4f);

                float spawnX = ((Mathf.Sqrt(3) * 5f) * x) + xOffset + transform.position.x;
                float spawnZ = (2f * 5f * 3f / 4f) * y + transform.position.z;
                GameObject spawnedObject = GameObject.Instantiate(Prefab, new Vector3(spawnX, 0, spawnZ), Prefab.transform.rotation, transform);
                spawnedObject.transform.localScale = new Vector3(spawnedObject.transform.localScale.x, spawnedObject.transform.localScale.y, Heightmap.GetPixel(x * sampleOffset, y * sampleOffset).grayscale * 10f * Strength);
                terrainPrefabs.Add(spawnedObject);
            }
        }
    }
}
