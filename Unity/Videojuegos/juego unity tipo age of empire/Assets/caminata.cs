using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class caminata : MonoBehaviour
{
    [SerializeField]private Transform targetTransform;
    Animator animator;
    private NavMeshAgent navMeshA;
    private int vida=100;
    public bool monoseleccionado = false;
    void Start()
    {
        //Debug.Log(GetInstanceID());
        animator=GetComponentInChildren<Animator>();
    }
    private void Awake(){
        navMeshA = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Debug.Log("scape");
            Application.Quit();
        }
        Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit)){
        if(Input.GetMouseButtonDown(1)){
            
            if(hit.collider.gameObject.name == name){
                monoseleccionado = true;
            }
            if(hit.collider.gameObject.name != name){
                monoseleccionado = false;
            }
            
        }
        if(monoseleccionado==true){
        if(Input.GetMouseButtonDown(0)){
        if(GetComponentInChildren<colisionjugador>().entrar==false){
               navMeshA.destination=hit.point;
        }
 }
          if(GetComponentInChildren<colisionjugador>().entrar==true && GetComponentInChildren<colisionjugador>().negro){
            navMeshA.destination=GetComponentInChildren<colisionjugador>().negro.transform.position;
        } else{
            GetComponentInChildren<colisionjugador>().entrar=false;
        }
        }
        }
        //Debug.Log(navMeshA.velocity.magnitude);
        if(navMeshA.velocity.magnitude<=0){
            
            animator.SetBool("enemigo",false);
        }else if(navMeshA.velocity.magnitude>=0){
            
            animator.SetBool("enemigo",true);
        }

        if(vida==0){
            Destroy(gameObject);
            GameObject.Find("jugar").GetComponent<creacion>().crear--;
        }

       // navMeshA.destination=targetTransform.position;
    }

    void OnCollisionStay(Collision collider){
        if(collider.gameObject.tag == "enemigo"){
            vida-=1;   
        }
    }
}
