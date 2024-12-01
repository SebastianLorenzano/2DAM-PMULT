using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    private GameManager gm;                              // Reference to the GameManager script
    AudioSource audioSource;
    [SerializeField] TextMeshProUGUI textGameOver;       // for displaying Game Over text
    [SerializeField] private TextMeshProUGUI textInfo;    // for displaying information to the player
    int items_left;                                      // Number of items left in the scene
    int maxItems;                                        // Maximum number of items in the scene

    void Start()
    {
        gm = GameManager.Instance;                          // Gets the GameManager script
        items_left = FindObjectsOfType<Item>().Length;      // Gets the number of items in the scene
        audioSource = GetComponent<AudioSource>();
        maxItems = items_left;
        textInfo.text = "Necesito encontrar gasolina para el auto... \n Latas revisadas: " + (maxItems - items_left) + " / " + maxItems;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddPoints()
    {
        gm.points += 100;
        items_left--;
        textInfo.text = "Necesito encontrar gasolina para el auto... \n Latas revisadas: " + (maxItems - items_left) +  " / " + maxItems;

        if (items_left == 0)
        {
            // Activate car
        }
    }


    public void PlayerLoseHp()
    {
        gm.health--;
        if (gm.health >= 1)
        {
            audioSource.Play();
            FindObjectOfType<Player>().SendMessage("SpawnInCheckpoint");        // Respawn the player at the last checkpoint

        }
        else
        {

            FindObjectOfType<Player>().gameObject.GetComponent<Renderer>().enabled = false;     // Hide the player when he dies 
            FinishGame();
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
        textGameOver.text = "Has escapado!\r\nPuntos: " + gm.points;
        StartCoroutine(LoadMainMenu());
    }
    private IEnumerator LoadMainMenu()                  // After a delay, loads the main menu
    {
        Time.timeScale = 0.1f;
        yield return new WaitForSeconds(0.3f);
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}