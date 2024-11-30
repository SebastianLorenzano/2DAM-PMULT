using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    SceneController sceneController;            // Gets everything needed for the item
    AudioSource audioSource;
    Renderer renderer;
    Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        sceneController = FindObjectOfType<SceneController>();      // Initizaling all the variables
        audioSource = GetComponent<AudioSource>();
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.tag == "Player")
        {
            Debug.Log("Pickup item");
            audioSource.Play();                 // Plays pickup sound
            renderer.enabled = false;           // Hides the item so the player doesn't see it anymore
            collider.enabled = false;           // Disables the collider so the player can't pick it up again
            sceneController.AddPoints();        // Adds points to the player
            Destroy(gameObject, 2f);            // Destroys it after 2 seconds so the audio can play before it disappears
        }
    }
}