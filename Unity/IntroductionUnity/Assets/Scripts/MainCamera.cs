using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCameraScript : MonoBehaviour
{
    public static float Width => Height * Camera.main.aspect;               // Gets the Width of the Camera at the moment its called
    public static float Height => 2 * Camera.main.orthographicSize;         // Gets the Height of the Camera at the moment its called
    public static float X => Camera.main.transform.position.x - Width / 2;  // Gets the X of the Camera at the moment its called
    public static float Y => Camera.main.transform.position.y - Height / 2; // Gets the Y of the Camera at the moment its called
    [SerializeField] public int level = 1;                                  // The level that the camera belongs to
    public UnityEngine.UI.Text txtEnd;

    void Start()
    {

    }

    void Update()
    {
        int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length; // Gets amount of enemies still alive
        if (enemyCount == 0)
        {
            if (level == 1)                                                 // If there are no enemies, it changes to the scene it has to or the game finishes
                gameObject.GetComponent<SceneLoader>().LaunchLevel2();  
            else if (level == 2)
            {
                txtEnd.text = "You win!";
                txtEnd.enabled = true;
            
            }           
        }
    }

}
