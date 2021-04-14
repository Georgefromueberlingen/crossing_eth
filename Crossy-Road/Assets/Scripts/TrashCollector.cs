/*using UnityEngine;
using System.Collections;

public class TrashCollector : MonoBehaviour
{

    public GameObject Cars;
    public Transform player;

    // Use this for initialization
    void Start()
    {
        GameObject[] Cars;
        void Start()
        {
            cars = GameObject.FindGameObjectsWithTag("Cars");
        }

        foreach (GameObject Cars in cars)
        {
            if (wall != null && Vector3.Distance(wall.transform.position, player.position) >= 10f)
            {
                Destroy(Cars);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        cars = GameObject.FindGameObjectsWithTag("Cars");
        foreach (GameObject Cars in cars)
        {
            if (Cars != null && Vector3.Distance(Cars.transform.position, player.position) >= 10f)
            {
                Destroy(Cars);
            }
        }
    }
}
*/