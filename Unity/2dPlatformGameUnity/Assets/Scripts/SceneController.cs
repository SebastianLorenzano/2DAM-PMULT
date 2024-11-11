using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{

    private GameManager gm;                              // Reference to the GameManager script
    int items_left;                                      // Number of items left in the scene
    AudioSource audioSource;
    [SerializeField] TextMeshProUGUI textGameOver;       // for displaying Game Over text
    [SerializeField] private Image[] hearts;             // Array of heart images representing player's health
    [SerializeField] private TextMeshProUGUI points;    // for displaying points

    void Start()
    {
        gm = GameManager.Instance;                          // Gets the GameManager script
        items_left = FindObjectsOfType<Item>().Length;      // Gets the number of items in the scene
        audioSource = GetComponent<AudioSource>();        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddPoints()
    {
        gm.points += 100;
        items_left--;
        points.text = "" + gm.points;
        if (items_left < 3)             // If there are less than 3 items left it destroys the key objects, allowing the player to advance in the game
            DestroyKeyObjects();
    }

    public void PlayerLoseHp()
    {
        gm.health--;
        if (gm.health >= 1)
        {
            audioSource.Play();
            FindObjectOfType<Player>().SendMessage("SpawnInCheckpoint");        // Respawn the player at the last checkpoint

            UpdateHeartsUI();               //  Update the hearts UI
        }
        else
        {
            UpdateHeartsUI();
            FindObjectOfType<Player>().gameObject.GetComponent<Renderer>().enabled = false;     // Hide the player when he dies 
            FinishGame();
        }
    }

    private void UpdateHeartsUI()
    {
        int health = gm.health;
        for (int i = 0; i < hearts.Length; i++)         // Loop through each heart Image and enable or disable it based on current health
        {
            if (i < health)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
        }
    }

    public void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;       // Get the current scene index
        int totalScenes = SceneManager.sceneCountInBuildSettings;               // Get the total number of scenes in the build settings

        // Check if the current scene is the last one
        if (currentSceneIndex < totalScenes - 1)
        {
            // Load the next scene
            SceneManager.LoadScene(currentSceneIndex + 1);          // Load the next scene, works for every scene in the build settings
        }
        else
            WinGame();                                              // If the current scene is the last one, the player wins the game
    }

    private void FinishGame()                           // Player loses the game
    {
        textGameOver.enabled = true;
        StartCoroutine(LoadMainMenu());
    }

    private void WinGame()                              // Player wins the game
    {
        textGameOver.enabled = true;
        textGameOver.text = "You WINN!!";
        StartCoroutine(LoadMainMenu());
    }
    private IEnumerator LoadMainMenu()                  // After a delay, loads the main menu
    {
        Time.timeScale = 0.1f;
        yield return new WaitForSeconds(0.3f);
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    private void DestroyKeyObjects()                    // Sends a message to the KeyObject script to destroy itself
    {
        FindObjectOfType<KeyObject>().SendMessage("DestroyYourself");
    }
}