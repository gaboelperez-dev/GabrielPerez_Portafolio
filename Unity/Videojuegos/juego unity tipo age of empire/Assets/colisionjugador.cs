using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisionjugador : MonoBehaviour
{
    public GameObject negro;
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
        if(collider.gameObject.tag == "enemigo"||collider.gameObject.tag == "enemigo2"){
            //Debug.Log("Entro el jugador");
            entrar=true;
            negro=collider.gameObject;
        }
    }
    void OnTriggerExit(Collider collider){
        if(collider.gameObject.tag == "enemigo"||collider.gameObject.tag == "enemigo2"){
            entrar=false;
        }
    }
}
