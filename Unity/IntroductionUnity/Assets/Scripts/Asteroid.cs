using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] protected Transform prefabExplotion;
    [SerializeField] protected Transform prefabAsteroid;
    [SerializeField] private float ySpeed = -1.0f;
    // Start is called before the first frame update
    void Start()
    {
        float x = mainCameraScript.X + 1 + Random.Range(0, mainCameraScript.Width - 1);
        float y = mainCameraScript.Y + mainCameraScript.Height + 4;
        transform.position = new Vector3(x, y, 0);
        StartCoroutine(CreateAsteroid());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, ySpeed * Time.deltaTime, 0);
        if (Collisions.IsOutOfBoundsSouth(gameObject))
            Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.tag == "Player")
            {
                Transform explosion = Instantiate(prefabExplotion,
                collision.transform.position, Quaternion.identity);
                Destroy(explosion.gameObject, 1f);
            }
            else if (collision.tag == "AllyBullet")
                Destroy(collision.gameObject);
        }
    }

    private IEnumerator CreateAsteroid()
    {

        float pause = Random.Range(1.5f, 3.0f);
        yield return new WaitForSeconds(pause);
        Instantiate(prefabAsteroid, new Vector3(0, 0, 0), Quaternion.identity);
    }

    private void IsHit()
    {

    }
}
