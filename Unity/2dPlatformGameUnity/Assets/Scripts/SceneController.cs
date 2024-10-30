using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class SceneController : MonoBehaviour
{
    int points = 0;
    int health = 3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints()
    {
        points += 100;
        Debug.Log("Puntos: " + points);
    }

    public void PlayerLoseHp()
    {
        FindObjectOfType<Player>().SendMessage("Recolocar");
        health--;
        Debug.Log("HP left: " + health);
        if (health <= 0)
        {
            Debug.Log("Partida terminada");
        
        }
    }
}
