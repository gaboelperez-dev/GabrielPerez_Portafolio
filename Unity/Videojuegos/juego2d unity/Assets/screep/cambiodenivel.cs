using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambiodenivel : MonoBehaviour
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
        
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "personaje"){
            //Debug.Log("lol");
            string levelname = scene.name; 
            if( levelname== "nivel1"){
            SceneManager.LoadScene(1);
            Destroy(gameObject);
            }
             if( levelname== "nivel2"){
            SceneManager.LoadScene(2);
            Destroy(gameObject);
            }
             
        }
    }
}
