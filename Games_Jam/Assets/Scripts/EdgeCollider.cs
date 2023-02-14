using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeCollider : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Friendly")
        {
            FindObjectOfType<GameManager>().GameOver();
            Debug.Log("GameOver");
        }

        else if (collision.tag == "Corrupt")
        {
            Destroy(collision.gameObject);
        }
    }
}
