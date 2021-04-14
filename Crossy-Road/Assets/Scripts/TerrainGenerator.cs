using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private int mindistanceFromPlayer;
    [SerializeField] private int maxTerrainCount;
    [SerializeField] private List<TerrainData> terrainDatas = new List<TerrainData>();
    [SerializeField] private Transform terrainHolder;

    private List<GameObject> currentTerrains = new List<GameObject>();
    [HideInInspector] public Vector3 currentPosition = new Vector3(0, 0, 0);


    private void Start()
    {
        for (int i = 0; i < maxTerrainCount; i++)
        {
            SpawnTerrain(true, new Vector3(0,0,0));
        }
        maxTerrainCount = currentTerrains.Count;
  
    }

    public void SpawnTerrain(bool isStart, Vector3 playerPos)
    {

        if ((currentPosition.x - playerPos.x < mindistanceFromPlayer) || (isStart))
        {
            int whichTerrain = Random.Range(0, terrainDatas.Count); // which ones were going to spawn
            int terrainInSuccession = Random.Range(1, terrainDatas[whichTerrain].maxInSuccession); // how many of them in succession
            for (int i = 0; i < terrainInSuccession; i++)
            {
                GameObject terrain = Instantiate(terrainDatas[whichTerrain].possibleTerrain[Random.Range(0,terrainDatas[whichTerrain].possibleTerrain.Count)], currentPosition, Quaternion.identity, terrainHolder);
                terrain.transform.SetParent(terrainHolder);
                currentTerrains.Add(terrain);
                if (!isStart)
                {
                    if (currentTerrains.Count > maxTerrainCount)
                    {

                        Destroy(currentTerrains[0]);
                        currentTerrains.RemoveAt(0);
                    }
                }
                currentPosition.x++;
            }

        }
        
        /*  first code for SpawnTerrain
        GameObject terrain = Instantiate(terrain[Random.Range(0, terrains.Count)], currentPosition, Quaternion.identity);
        currentTerrains.Add(terrain);
        if(currentTerrains.Count > maxTerrainCount)
        {

            Destroy(currentTerrains[0]);
            currentTerrains.RemoveAt(0);
        }
        currentPosition.x++;
        */

    }
}
