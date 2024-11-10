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
    AudioSource audioSource;

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
        Debug.Log("Puntos: " + gm.points);
        items_left--;
        if (items_left < 3)
            DestroyKeyObjects();
    }

    public void PlayerLoseHp()
    {
        if (gm.health > 0)
        {
            audioSource.Play();
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