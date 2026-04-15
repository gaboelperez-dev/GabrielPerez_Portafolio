using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class creacion : MonoBehaviour
{
    public GameObject jugador;
    private NavMeshAgent navMeshA2;
    public int crear=1;
    public bool hacer=true;
    public float time=10;
    int numeroEnemigo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit)){
        if(Input.GetMouseButtonDown(1)){
            //Debug.Log(hit.collider.gameObject.name);
            if(hit.collider.gameObject.name == "Cylinder"){
                if(hacer==true){
                if(crear<=4){
                    crear++;
                GameObject jugar = Instantiate(jugador,transform.position,Quaternion.identity);
                jugar.name = "Enemigo" + numeroEnemigo;
                numeroEnemigo++;
                hacer=false;
                }
                }
            }
            
        
    }
        }
        if(hacer==false){
                time-= 1*Time.deltaTime;
                
            }
            if(time<=0){
                hacer=true;
                time=10;
            }
    }
}
