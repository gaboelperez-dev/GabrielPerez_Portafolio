using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ganarnivel1 : MonoBehaviour
{
     private new Rigidbody rigibody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collision){
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name == "carro"){
             SceneManager.LoadScene(2);
        }
         
    }
}
