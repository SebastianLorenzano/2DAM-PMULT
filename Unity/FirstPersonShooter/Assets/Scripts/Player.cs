using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{   
    // Utilizamos la cámara para el RayCast
    [SerializeField] Camera camara;    
    [SerializeField] GameObject pistol;
    [SerializeField] Transform prefabMuzzleFlash;
    private Vector3 shootParticlesEffectPosition;
    private AudioSource audioSource;
    private bool canShoot = true;

    Vector3 gunBarrel = new Vector3(0, 0.14f, 0.4f);   // This magic numbers are the position of the barrel of the gun

    // Start is called before the first frame update
    void Start()
    {
        shootParticlesEffectPosition = pistol.transform.position + gunBarrel;
        audioSource = GetComponent<AudioSource>();

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            StartCoroutine(ShootingCooldown());
            SpawnMuzzleFlash();
            audioSource.Play();
            Debug.Log("Disparando...");
            
            float distanciaMaxima = 50;
            RaycastHit hit;
            bool impactado = Physics.Raycast(camara.transform.position,
            camara.transform.forward, out hit, distanciaMaxima);
            if (impactado)
            {
                Debug.Log("Disparo impactado");
                if (hit.collider.CompareTag("Enemy"))
                {
                    Debug.Log("Enemigo acertado");
                    hit.collider.gameObject.SendMessage("TakeDamage");
                }
            }
        }
    }

    private IEnumerator ShootingCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
    }

    private void SpawnMuzzleFlash()
    {
        // Calculate the position of the muzzle flash in world space
        Vector3 muzzleFlashWorldPosition = pistol.transform.TransformPoint(gunBarrel);

        // Use the gun's forward direction to orient the muzzle flash
        Quaternion muzzleFlashRotation = pistol.transform.rotation;

        // Instantiate the muzzle flash prefab at the correct position and rotation
        var explosion = Instantiate(prefabMuzzleFlash, muzzleFlashWorldPosition, muzzleFlashRotation);

        // Automatically destroy the particle system after its duration
        ParticleSystem particleSystem = explosion.GetComponent<ParticleSystem>();
        if (particleSystem != null)
        {
            Destroy(particleSystem.gameObject, particleSystem.main.duration);
        }
    }

}
