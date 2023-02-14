using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutants : MonoBehaviour
{
    int speed;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        speed = 15;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
    }

    // Update is called once per frame
    void Update()
    {
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Friendly")
            {
                Destroy(collision.gameObject);
            }

            if (collision.tag == "Corrupt")
            {
                FindObjectOfType<GameManager>().GameOver();
                Debug.Log("PlayerGameObject");
            }
        }   
    }
}
