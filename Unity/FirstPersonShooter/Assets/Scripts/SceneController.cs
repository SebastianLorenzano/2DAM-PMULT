using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.SceneManagement;
using Microsoft.Unity.VisualStudio.Editor;
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

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gm = GameManager.Instance;                          // Gets the GameManager script
        items_left = FindObjectsOfType<Item>().Length;      // Gets the number of items in the scene
        maxItems = items_left;
        textInfo.text = "Necesito encontrar gasolina para el auto... \n Latas revisadas: " + (maxItems - items_left) + " / " + maxItems;
        UpdateBloodOverlay();
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
            textInfo.text = "Haz encontrado la gasolina! \n Corre al coche antes de que te agarre la horda!!";
        }
    }


    public IEnumerator PlayerLoseHp()
    {
        yield return new WaitForSeconds(0.5f);
        gm.health--;
        if (gm.health >= 0)
        {
            UpdateBloodOverlay();
            audioSource.PlayOneShot(audPlayerHit, 0.6f); // Play the sound
        }
        else
        {
            FinishGame();
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
            Debug.Log($"Health: {gm.health}, Target Alpha: {alpha}, Current Alpha: {currentAlpha}");

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