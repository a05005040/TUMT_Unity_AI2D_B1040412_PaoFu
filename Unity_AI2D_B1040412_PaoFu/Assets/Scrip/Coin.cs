using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject Main,Player;


    void Start()
    {
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name== "Player")
        {          
            Main.GetComponent<Main>().GetCoin();
            Player.GetComponent<Player>().GetCoin();
            Destroy(gameObject);
        }
    }
}
