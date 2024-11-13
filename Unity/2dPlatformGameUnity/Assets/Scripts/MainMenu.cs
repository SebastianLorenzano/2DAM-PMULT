using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Load the next scene in the build order (e.g., the first level)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);       //  Executes the next scene in the build order
    }
}