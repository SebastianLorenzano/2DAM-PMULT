using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;         // Singleton
    public int points = 0;                      // Player points
    public int health = 3;                      // Player health
    public int maxHealth => 3;                  // Property that gives the maximum health, it doesn't aim to points so it is constant

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            var audio = Instance.GetComponent<AudioSource>();       // Stops and starts the audio when the scene is loaded and the gameMAnager was already created
            audio.Stop();
            audio.Play();
            Destroy(gameObject);

        }

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
