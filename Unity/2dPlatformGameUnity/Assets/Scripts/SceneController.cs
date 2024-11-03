using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textGameOver;
    private GameManager gm;
    int items_left;

    void Start()
    {
        gm = GameManager.Instance;
        items_left = FindObjectsOfType<Item>().Length;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddPoints()
    {
        gm.points += 100;
        Debug.Log("Puntos: " + gm.points);
        items_left--;
        if (items_left == 0)
        {
            NextLevel();
        }
    }

    public void PlayerLoseHp()
    {
        if (gm.health > 0)
        {
            FindObjectOfType<Player>().SendMessage("SpawnInCheckpoint");
            gm.health--;
            Debug.Log("HP left: " + gm.health);
        }
        else
        {
            Debug.Log("Partida terminada");
            FinishGame();
        }
    }

    public void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        // Check if the current scene is the last one
        if (currentSceneIndex < totalScenes - 1)
        {
            // Load the next scene
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            Debug.Log("This is the last level. No more levels to load.");
            // Optional: Add additional logic here if needed (e.g., show a message or trigger an event)
        }
    }

    private void FinishGame()
    {
        textGameOver.enabled = true;
        StartCoroutine(LoadMainMenu());
    }
    private IEnumerator LoadMainMenu()
    {
        Time.timeScale = 0.1f;
        yield return new WaitForSeconds(0.3f);
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}