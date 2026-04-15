using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemigomov : MonoBehaviour
{
    Animator animator;
    [SerializeField]private Transform targetTransform;
    private NavMeshAgent navMeshA;
    private int vida=100;
    public bool muerte = false;
    void Start()
    {
        animator=GetComponentInChildren<Animator>();
    }

    private void Awake(){
        navMeshA = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponentInChildren<colision>().entrar!=false && GetComponentInChildren<colision>().blanco){
         navMeshA.destination=GetComponentInChildren<colision>().blanco.transform.position;
        }else{
            GetComponentInChildren<colision>().entrar=false;
        }
        if(vida==0){
            GameObject.Find("crearene").GetComponent<crearenemigo>().crear--;
            //muerte=true;
            Destroy(gameObject);
        }
        if(navMeshA.velocity.magnitude<=0){
            
            animator.SetBool("enemigo",false);
        }else if(navMeshA.velocity.magnitude>=0){
            
            animator.SetBool("enemigo",true);
        }
    }
    void OnCollisionStay(Collision collider){
        //Debug.Log(collider.gameObject.name);
        if(collider.gameObject.tag == "Player"){
            vida-=5;   
        }
    }
}
