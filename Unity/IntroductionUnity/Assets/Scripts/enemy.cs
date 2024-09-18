using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] private float xSpeed = 2;
    [SerializeField] private float ySpeed = -1.0f;
    [SerializeField] Transform prefabEnemyBullet;


    void Start()
    {
        StartCoroutine(Disparar());
    }


    void Update()
    {
        transform.Translate(xSpeed * Time.deltaTime,ySpeed * Time.deltaTime, 0);
        if ((transform.position.x < -6.60) || (transform.position.x > 6.60))
            xSpeed = -xSpeed;
        else if ((transform.position.y < -2.80) || (transform.position.y > 2.80))
            ySpeed = -ySpeed;
    }

    IEnumerator Disparar()
    {
        float pause = Random.Range(3.0f, 8.0f);
        yield return new WaitForSeconds(pause);
        Transform disparo = Instantiate(prefabEnemyBullet, transform.position, Quaternion.identity);
        StartCoroutine(Disparar());
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.tag == "Player" || collision.tag == "AllyBullet")
                Destroy(gameObject);
        }
    }
}
