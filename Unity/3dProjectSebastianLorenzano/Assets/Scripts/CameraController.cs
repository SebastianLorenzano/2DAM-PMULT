using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // El objeto al que sigue la c�mara. Se asigna en el editor de Unity
    public GameObject player;
    // Vector que guardar� la distancia entre la c�mara y el objeto que 
    private Vector3 offset;

    void Start()
    {
        // Obtenemos al principio del juego la distancia entre 
        // la c�mara y el objeto que sigue.
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Hacemos que la posici�n de la c�mara sea la posici�n
        // del jugador m�s la distancia calculada al principio.
        transform.position = player.transform.position + offset;
    }
}
