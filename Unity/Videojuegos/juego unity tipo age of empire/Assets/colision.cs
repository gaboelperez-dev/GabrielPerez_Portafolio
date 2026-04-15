using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colision : MonoBehaviour
{
    public GameObject blanco;
    public bool entrar=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collider){
        //Debug.Log(collider.gameObject.name);
        if(collider.gameObject.tag == "Player"){
            //Debug.Log("Entro el jugador");
            entrar=true;
            blanco=collider.gameObject;
        }
    }
    void OnTriggerExit(Collider collider){
        if(collider.gameObject.tag == "Player"){
            entrar=false;
        }
    }
}
