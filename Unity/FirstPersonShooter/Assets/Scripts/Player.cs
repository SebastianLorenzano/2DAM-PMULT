using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{   
    [SerializeField] Camera camara;                     // This is the camera of the player
    [SerializeField] GameObject pistol;                 // This is the gun of the player
    [SerializeField] Transform prefabMuzzleFlash;       // This is the muzzle flash prefab
    private Vector3 shootParticlesEffectPosition;
    private AudioSource audioSource;
    private bool canShoot = true;                       // This is a flag to prevent the player from shooting too fast

    Vector3 gunBarrel = new Vector3(0, 0.14f, 0.4f);   // These magic numbers are the position of the barrel of the gun

    // Start is called before the first frame update
    void Start()
    {
        shootParticlesEffectPosition = pistol.transform.position + gunBarrel;           // This is the position of the muzzle flash, the barrel of the gun
        audioSource = GetComponent<AudioSource>();

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)               // If the player presses the left mouse button and can shoot
        {
            StartCoroutine(ShootingCooldown());                     // Disables shooting for a short period of time
            SpawnMuzzleFlash();                                     // Spawns the muzzle flash
            audioSource.Play();                                     // Plays the shooting sound
 
            float distanciaMaxima = 50;                                     // Checks for hits
            RaycastHit hit;
            bool impactado = Physics.Raycast(camara.transform.position,
            camara.transform.forward, out hit, distanciaMaxima);
            if (impactado)                                              // if the raycast hits something, checks if its an enemy
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    Debug.Log("Enemigo acertado");
                    hit.collider.gameObject.SendMessage("TakeDamage");          // If it is an enemy, sends the TakeDamage message
                }
            }
        }
    }

    private IEnumerator ShootingCooldown()          // Disables and enables back shooting after a bit
    {
        canShoot = false;
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
    }

    private void SpawnMuzzleFlash()
    {
        Vector3 muzzleFlashWorldPosition = pistol.transform.TransformPoint(gunBarrel);                     // Calculate the position of the muzzle flash in world space
        Quaternion muzzleFlashRotation = pistol.transform.rotation;                                        // Use the gun's forward direction to orient the muzzle flash
        var explosion = Instantiate(prefabMuzzleFlash, muzzleFlashWorldPosition, muzzleFlashRotation);     // Instantiate the muzzle flash prefab

        ParticleSystem particleSystem = explosion.GetComponent<ParticleSystem>();           //  Get the particle system component and destroys it after the duration of the particle system wasn't destroyed yet
        if (particleSystem != null)
        {
            Destroy(particleSystem.gameObject, particleSystem.main.duration);
        }
    }

}
