using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public bool MutantOneLane, MutantTwoLane;
    public bool MutantOne;

    public Vector2 Xpos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left"))
        {
            MoveLeft();
        }

        if (Input.GetKeyDown("right"))
        {
            MoveRight();
        }

        if (MutantOne)
        {
            if (MutantOneLane)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(-Xpos.y, transform.position.y, 0), .25f);
            }

            else 
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(-Xpos.x, transform.position.y, 0), .25f);
            }

        }

        else 
        {
            if (MutantTwoLane)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(Xpos.y, transform.position.y, 0), .25f);
            }

            else 
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(Xpos.x, transform.position.y, 0), .25f);
            }
        }
        
    }

    public void MoveLeft()
    {
        if (MutantOneLane)
        {
            MutantOneLane = false;
        }

        else
        {
            MutantOneLane = true;
        }
    }

    public void MoveRight()
    {
        if (MutantTwoLane)
        {
            MutantTwoLane = false;
        }

        else
        {
            MutantTwoLane = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Something");
        if (collision.tag == "Friendly")
        {
            FindObjectOfType<GameManager>().AddScore();
            Destroy(collision.gameObject);
            //Debug.Log("Trigger");
        }

        if (collision.tag == "Corrupt")
        {
            FindObjectOfType<GameManager>().GameOver();
            //Debug.Log("PlayerGameObject");
        }
    }
}
