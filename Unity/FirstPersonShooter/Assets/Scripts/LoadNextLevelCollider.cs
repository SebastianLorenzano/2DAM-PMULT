using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextLevelCollider : MonoBehaviour      // This collider is used to load the next level when the player enters it
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.tag == "Player")
            FindObjectOfType<SceneController>().SendMessage("NextLevel");       // Load next level
    }
}
