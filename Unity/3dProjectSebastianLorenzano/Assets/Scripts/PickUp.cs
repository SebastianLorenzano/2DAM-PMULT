using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{

    private Renderer r;
    private AudioSource audioSource;        //Audio source component attached
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
        StartCoroutine(ChangeColor());
        audioSource = GetComponent<AudioSource>();
        audioSource.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(4f);
        r.material.color = new Color(Random.value, Random.value, Random.value);
        StartCoroutine(ChangeColor());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
                    //If I destroy it or disable it, the audio doesn't work
            Destroy(gameObject, 2f);
        }
    }
}
