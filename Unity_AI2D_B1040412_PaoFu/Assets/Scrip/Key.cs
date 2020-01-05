using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject Player,Box,Main;


    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            Player.GetComponent<Player>().GetKey();
            Box.GetComponent<Box>().Complete();
            Main.GetComponent<Main>().GetKey();
            Destroy(gameObject);
        }
    }
}
