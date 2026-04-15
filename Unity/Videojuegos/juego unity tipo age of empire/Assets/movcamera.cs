using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movcamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButton(2)){
            float movx=Input.GetAxis("Mouse X");
            float movy=Input.GetAxis("Mouse Y");
            if(transform.position.x > -36 && movx > 0){
               transform.Translate(movx*-.5f,0,0);
            } else if(transform.position.x < 4 && movx < 0){
                transform.Translate(movx*-.5f,0,0);
            }
            if(transform.position.z > 0 && movy > 0){
               transform.Translate(0,movy*-.5f,0);
            } else if(transform.position.z<27 && movy < 0){
                transform.Translate(0,movy*-.5f,0);
            }
           }
        
        
    }
}
