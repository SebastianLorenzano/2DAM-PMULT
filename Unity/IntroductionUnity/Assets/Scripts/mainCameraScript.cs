using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCameraScript : MonoBehaviour
{
    public static float Width => Height * Camera.main.aspect;
    public static float Height => 2 * Camera.main.orthographicSize;
    public static float X => Camera.main.transform.position.x - Width / 2;
    public static float Y => Camera.main.transform.position.y - Height / 2;
    [SerializeField] public int level = 1;
    public UnityEngine.UI.Text txtEnd;

    void Start()
    {

    }

    void Update()
    {
        int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount == 0)
        {
            if (level == 1)
                gameObject.GetComponent<SceneLoader>().LaunchLevel2();
            else if (level == 2)
            {
                txtEnd.text = "You win!";
                txtEnd.enabled = true;
            
            }           
        }
    }

}
