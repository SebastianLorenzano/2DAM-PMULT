using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextLevelCollider : MonoBehaviour      // This collider is used to load the next level when the player enters it
{
    [SerializeField] private SceneController sceneController;        // Reference to the SceneController script
    // Start is called before the first frame update
    void Start()
    {
        sceneController = FindObjectOfType<SceneController>();        // Gets the SceneController script
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision != null && sceneController.canGoToNextLevel && collision.gameObject.tag == "Player")      // If the player enters the collider and the SceneController allows it
        {
            FindObjectOfType<SceneController>().SendMessage("NextLevel");       // Load Next level
        }
    }
}
