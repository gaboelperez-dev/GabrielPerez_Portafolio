using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    public GameObject jugador;
    Scene scene;
    private float tiempodejuego=0;
    public Text contador;
    public bool n2 = true; 
    
    // Start is called before the first frame update
    void Start()
    {
         scene=SceneManager.GetActiveScene();
         string levelname = scene.name;
        if(levelname=="nivel1"){
        tiempodejuego=32;
        
        }
        if(levelname=="nivel2.1"){
        if(n2==true){
       tiempodejuego=55;
       n2=false;
        }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        string levelname = scene.name;
        if(jugador.GetComponent<WheelController>().re==true){
            tiempodejuego+=5;
            jugador.GetComponent<WheelController>().re=false;
        }
        if(levelname=="nivel2.1"){
        if(n2==true){
       tiempodejuego=50;
       n2=false;
        }
        }
       
        
       tiempodejuego -= Time.deltaTime; 
       contador.text =" "+ tiempodejuego.ToString("f0");
       if(tiempodejuego<=0){
        Debug.Log(tiempodejuego);
        
        if(levelname=="nivel1"){
        SceneManager.LoadScene(4);
        
        }
        if(levelname=="nivel2.1"){
        SceneManager.LoadScene(5);
       
        }
       }
    }
}
