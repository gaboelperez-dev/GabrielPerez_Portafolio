using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cambio : MonoBehaviour
{
    public Text letra;
    // Start is called before the first frame update
    void Start()
    {
        letra.text ="Chales carnal que transas mi nombre es el joaquin y soy corredor de autos callejero ";
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey("mouse 0")){
        letra.text ="Me dicen que quieres pertenecer a mi grupo pues veamos si traes con queso";
        if (Input.GetKey("mouse 0")){
        SceneManager.LoadScene(1);
        
       }
       }
    }
}
