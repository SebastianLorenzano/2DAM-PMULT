using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // El objeto al que sigue la cámara. Se asigna en el editor de Unity
    public GameObject player;
    // Vector que guardará la distancia entre la cámara y el objeto que 
    private Vector3 offset;

    void Start()
    {
        // Obtenemos al principio del juego la distancia entre 
        // la cámara y el objeto que sigue.
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Hacemos que la posición de la cámara sea la posición
        // del jugador más la distancia calculada al principio.
        transform.position = player.transform.position + offset;
    }
}
