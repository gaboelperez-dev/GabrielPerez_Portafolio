using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crearenemigo : MonoBehaviour
{
    public bool hacer=true;
    public float time=15;
    int numeroEnemigo;
    public int crear=2;
    public GameObject jugador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(hacer==true){
                if(crear<=4){
                    crear++;
                GameObject crearene = Instantiate(jugador,transform.position,Quaternion.identity);
                hacer=false;
                
                }
                }
                if(hacer==false){
                time-= 1*Time.deltaTime;
                }
                if(time<=0){
                hacer=true;
                time=15;
            }
            
    }
}
