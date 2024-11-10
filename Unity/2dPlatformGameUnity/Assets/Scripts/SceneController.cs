using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{

    private GameManager gm;
    int items_left;
    AudioSource audioSource;
    [SerializeField] TextMeshProUGUI textGameOver;
    [SerializeField] private Image[] hearts;
    [SerializeField] private TextMeshProUGUI points;

    void Start()
    {
        gm = GameManager.Instance;
        items_left = FindObjectsOfType<Item>().Length;
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
        if (items_left < 3)
            DestroyKeyObjects();
    }

    public void PlayerLoseHp()
    {
        gm.health--;
        if (gm.health >= 1)
        {
            audioSource.Play();
            FindObjectOfType<Player>().SendMessage("SpawnInCheckpoint");

            UpdateHeartsUI();
        }
        else
        {
            UpdateHeartsUI();
            FindObjectOfType<Player>().gameObject.GetComponent<Renderer>().enabled = false;
            FinishGame();
        }
    }

    private void UpdateHeartsUI()
    {
        int health = gm.health;
        // Loop through each heart Image and enable or disable it based on current health
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
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
            WinGame();
            // Optional: Add additional logic here if needed (e.g., show a message or trigger an event)
        }
    }

    private void FinishGame()
    {
        textGameOver.enabled = true;
        StartCoroutine(LoadMainMenu());
    }

    private void WinGame()
    {
        textGameOver.enabled = true;
        textGameOver.text = "You WINN!!";
        StartCoroutine(LoadMainMenu());
    }
    private IEnumerator LoadMainMenu()
    {
        Time.timeScale = 0.1f;
        yield return new WaitForSeconds(0.3f);
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    private void DestroyKeyObjects()
    {
        FindObjectOfType<KeyObject>().SendMessage("DestroyYourself");
    }
}