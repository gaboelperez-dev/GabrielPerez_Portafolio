using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class regresarnivel : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
       if (Input.GetKey("escape")){
        SceneManager.LoadScene(0);
       }
    else if (!Input.GetButtonDown("Fire1") && Input.anyKeyDown){
        SceneManager.LoadScene(1);
        
        
    }
    }
}
