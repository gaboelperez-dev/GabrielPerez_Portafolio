using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class vidatorreenemiga : MonoBehaviour
{
    public float vida = 1000f;
    public Image vidas;
    public float vidamaxima=1000f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(vida==0){
            SceneManager.LoadScene(3);
            Destroy(gameObject);
        }
        vidas.fillAmount = vida / vidamaxima;
    }
    void OnCollisionStay(Collision collider){
        if(collider.gameObject.tag == "Player"){
            vida-=1;   
        }
    }
}
