using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 3.0f;
    [SerializeField] protected Transform prefabExplotion;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, bulletSpeed, 0);
    }

}
