using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnObject;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float minSeparationTime;
    [SerializeField] private float maxSeparatíonTime;
    [SerializeField] private bool isRightSide;

    private void Start()
    {
        StartCoroutine(SpawnVehicle());
    }
    private IEnumerator SpawnVehicle()
    {   
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(minSeparationTime, maxSeparatíonTime));
            GameObject go = Instantiate(spawnObject, spawnPos.position, Quaternion.identity);
            if(!isRightSide)
            {
                go.transform.Rotate(new Vector3(0, 180, 0));
            }
        }
    }
}
