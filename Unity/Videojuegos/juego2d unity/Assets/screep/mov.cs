using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov : MonoBehaviour
{
     public GameObject jugador;
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.Find("personaje");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
