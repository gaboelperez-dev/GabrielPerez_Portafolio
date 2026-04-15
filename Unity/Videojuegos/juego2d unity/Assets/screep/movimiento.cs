using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    private float posx = 2f;
    //private float posy = 3f;
    private float tiempo;
    private int rutina;
    private int vida = 3;
    public GameObject jugador;
    private float distancia_seguir =5f;
    // Start is called before the first frame update
    Rigidbody2D body;
    void Start()
    {
        jugador = GameObject.Find("personaje");
        body=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 JugadorPos=jugador.transform.position;
        Vector3 SelPos=transform.position;
        Vector3 direccion = Vector3.Normalize(JugadorPos-SelPos);
        float distancia = Vector3.Distance(JugadorPos,SelPos);
        if(distancia<distancia_seguir){
            body.velocity = new Vector2(direccion.x*2,direccion.y*2);
        }
        else{
        tiempo += 1 * Time.deltaTime;
        if(tiempo>=2){
            rutina = Random.Range(1,4);
            tiempo=0;
        }
        switch(rutina){
            case 0:
            case 1:
            body.velocity = new Vector2(posx * -1, 0);
            //transform.Translate(new Vector3(posx * -1, 0, 0));
            break;
            case 2:
            body.velocity = new Vector2(posx , 0);
            //transform.Translate(new Vector3(posx , 0, 0));
            break;
            case 3:
            body.velocity = new Vector2(0 , posx * -1);
            //transform.Translate(new Vector3(0 , posx * -1, 0));
            break;
            case 4:
            body.velocity = new Vector2(0 , posx);
            //transform.Translate(new Vector3(0 , posx, 0));
            break;
            case 5:
             body.velocity = new Vector2(0, posx * -1);
            break;
            case 6:
             body.velocity = new Vector2(posx, posx);
            break;
            case 7:
             body.velocity = new Vector2(posx * -1, posx * -1);
            break;
            case 8:
             body.velocity = new Vector2(posx, posx * -1);
            break;
            default:
            break;
        }
        }    
    }
    void OnCollisionEnter2D(Collision2D collision){
        //Debug.Log(collision.gameObject.name);
        
         if(collision.gameObject.name == "paredes" || collision.gameObject.tag == "Enemigo"){
         rutina+=1;
         tiempo=0;
         }
          if(collision.gameObject.name == "arma(Clone)"){
         vida--;
         //rutina+=2;
         tiempo=2;
            if(vida<=0){
                Destroy(gameObject);
            }
         }

         }
}
