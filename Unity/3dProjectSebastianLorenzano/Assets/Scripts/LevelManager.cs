using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private int level; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int pickUpCount = GameObject.FindGameObjectsWithTag("PickUp").Length; // Gets amount of pickUps still left
        if (pickUpCount == 0)
        {
            if (level == 1)
            {
                LaunchLevel2();
            }
        }
    }

    public static void LaunchGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LaunchLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
}
