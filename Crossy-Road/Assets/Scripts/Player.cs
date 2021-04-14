using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private TerrainGenerator terrainGenerator;
    [SerializeField] private Text scoreText;


    private Animator animator;
    private bool isHopping;
    private int score;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    private void FixedUpdate()
    {
         score++; // 60fps 60 score
    }


    
    private void Update()
    {
        scoreText.text = "Score: " + score;  // score handling

        if(Input.GetKeyDown(KeyCode.W) && !isHopping)
        {
            float zDifference = 0;
            //Debug.Log(transform.position);
            if(transform.position.z % 1 != 0) //gerade Zahl für schritte
            {
                // Debug.Log("On Grid Space"); // kann nicht gerade aus falls noch dabei nach links oder rechts zu gehen
                //transform.position = (transform.position + new Vector3(1, 0, 0));
                zDifference = Mathf.Round(transform.position.z) - transform.position.z; // round that value
            }
            MoveCharacter(new Vector3(1, 0, zDifference));
        }

        if (Input.GetKeyDown(KeyCode.S) && !isHopping)
        {
            float zDifference = 0;
            //Debug.Log(transform.position);
            if (transform.position.z % 1 != 0) //gerade Zahl für schritte
            {
                // Debug.Log("On Grid Space"); // kann nicht gerade aus falls noch dabei nach links oder rechts zu gehen
                //transform.position = (transform.position + new Vector3(1, 0, 0));
                zDifference = Mathf.Round(transform.position.z) - transform.position.z; // round that value
            }
            MoveCharacter(new Vector3(-1, 0, zDifference));
        }

        else if(Input.GetKeyDown(KeyCode.A) && !isHopping)
        {
            MoveCharacter(new Vector3(0, 0, 1));
        }
        else if (Input.GetKeyDown(KeyCode.D) && !isHopping)
        {
            MoveCharacter(new Vector3(0, 0, -1));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<MovingObject>() != null)
        {
            if(collision.collider.GetComponent<MovingObject>().isLog)
            {
                transform.parent = collision.collider.transform;
            }
        }
        else
        {
            transform.parent = null;
        }
    }


    private void MoveCharacter(Vector3 difference)
    {
        animator.SetTrigger("hop");
        isHopping = true;
        transform.position = (transform.position + difference);

        terrainGenerator.SpawnTerrain(false, transform.position);
    }


    public void FinishHop()
    {
        isHopping = false;
    }



}
