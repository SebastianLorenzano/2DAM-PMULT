using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{

    private GameManager gm;                              // Reference to the GameManager script
    AudioSource audioSource;
    [SerializeField] AudioClip audPlayerHit;
    [SerializeField] TextMeshProUGUI textGameOver;       // for displaying Game Over text
    [SerializeField] private TextMeshProUGUI textInfo;    // for displaying information to the player
    [SerializeField] private RawImage bloodOverlay;         // for displaying blood overlay when player is hit
    int items_left;                                      // Number of items left in the scene
    int maxItems;                                        // Maximum number of items in the scene
    public bool canGoToNextLevel = false;                // If the player can go to the next level

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gm = GameManager.Instance;                          // Gets the GameManager script
        items_left = FindObjectsOfType<Item>().Length;      // Gets the number of items in the scene
        maxItems = items_left;                              // Gets the maximum number of pickup items in the scene

        if (SceneManager.GetActiveScene().buildIndex == 1)  // If the scene is the first level, display the following text
        {
            textInfo.text = "Maldicion, me quede sin gasolina... \n Debo seguir a pie, no deberia estar lejos... \n Objetivo: Llega al porton";
            canGoToNextLevel = true;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2) // If the scene is the second level, display the following text
            textInfo.text = "Necesito encontrar gasolina para el auto... \n Latas revisadas: " + (maxItems - items_left) + " / " + maxItems;
        UpdateBloodOverlay();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddPoints() // Adds points to the game manager
    {
        gm.points += 100;
    }
    public void GotPickup()
    {
        AddPoints();
        items_left--;           // Decrease the count of items left 
        textInfo.text = "Necesito encontrar gasolina para el auto... \n Latas revisadas: " + (maxItems - items_left) + " / " + maxItems; // Update the text

        if (items_left == 0)        // Can go to next level once all items are picked up
        {
            canGoToNextLevel = true;        
            textInfo.text = "Has encontrado la gasolina! \n Vuelve al coche y sal de ahí!";
        }
    }


    public IEnumerator PlayerLoseHp()
    {
        yield return new WaitForSeconds(0.5f);      // Wait for a short delay before taking damage
        audioSource.PlayOneShot(audPlayerHit);      // Play the sound of the player being hit
        gm.health--;                                // Decrease the health of the player
        if (gm.health >= 0)                                  // If the player still has health
        {
            UpdateBloodOverlay();                           // Update the blood overlay
        }
        else
        {
            FinishGame();           // If the player has no health left, finish the game
        }
    }

    private void UpdateBloodOverlay()
    {
        if (bloodOverlay != null)
        {
            // Calculate the alpha value based on health lost
            float alpha = 1f - Mathf.Clamp01(gm.health / gm.maxHealth);

            // Scale alpha to a maximum of 0.6 (60% opacity)
            alpha *= 0.1f;

            Color overlayColor = bloodOverlay.color;
            overlayColor.a = alpha; 
            float currentAlpha = bloodOverlay.color.a;
            bloodOverlay.color = overlayColor;
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

    private void FinishGame()                                            // Player loses the game
    {
        textGameOver.enabled = true;                                     // Enable the Game Over text
        textGameOver.text = "Has muerto!\r\nPuntos: " + gm.points;      // Display the points the player got
        StartCoroutine(LoadMainMenu());                                 // Load the main menu
    }

    private void WinGame()                              // Player wins the game
    {
        textGameOver.enabled = true;                                    // Enable the Game Over text
        textGameOver.text = "Has escapado!\r\nPuntos: " + gm.points;    // Display the points the player got
        StartCoroutine(LoadMainMenu());                             // Load the main menu
    }
    private IEnumerator LoadMainMenu()                  // After a delay, loads the main menu
    {
        Time.timeScale = 0.1f;                          // Slow time
        yield return new WaitForSeconds(0.3f);          // Wait for 3 seconds
        Time.timeScale = 1;                             // Return time to normal
        gm.GetComponent<AudioSource>().Stop();           // Stop the background music
        SceneManager.LoadScene("MainMenu");             // Load the main menu
    }
}