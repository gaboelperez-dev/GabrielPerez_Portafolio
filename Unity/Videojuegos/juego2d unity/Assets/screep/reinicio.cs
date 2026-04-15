using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class reinicio : MonoBehaviour
{
    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + scene.name + "'.");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.anyKeyDown)
        {
            Debug.Log(Input.GetButtonDown("Fire1"));
            if (Input.GetButtonDown("Fire1") == false)
            {
                Debug.Log("cambiar escena");
                string levelname = scene.name;
                if (levelname == "lose")
                {
                    SceneManager.LoadScene(0);
                }
                if (levelname == "win")
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
    }
}
