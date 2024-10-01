using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var audio = GetComponent<AudioSource>();
        if (audio != null)
            audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LaunchGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LaunchLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void ExitGame()
    {
        Debug.Log("Exiting game.");
        Application.Quit();
    }
}
