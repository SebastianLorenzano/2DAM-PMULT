using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    SceneController sceneController;
    AudioSource audioSource;
    Renderer renderer;
    Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        sceneController = FindObjectOfType<SceneController>();
        audioSource = GetComponent<AudioSource>();
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.tag == "Player")
        {
            Debug.Log("Pickup item");
            audioSource.Play();
            renderer.enabled = false;
            collider.enabled = false;
            sceneController.AddPoints();
            Destroy(gameObject, 2f);
        }
    }
}

