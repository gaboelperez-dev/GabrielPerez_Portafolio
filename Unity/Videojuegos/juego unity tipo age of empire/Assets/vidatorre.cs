using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class vidatorre : MonoBehaviour
{
    // Start is called before the first frame update
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
            SceneManager.LoadScene(2);
            Destroy(gameObject);
        }
        vidas.fillAmount = vida / vidamaxima;
    }
    void OnCollisionStay(Collision collider){
        if(collider.gameObject.tag == "enemigo"){
            vida-=1;   
        }
        if (Input.GetKey("escape"))
        {
            Debug.Log("scape");
            Application.Quit();
        }
    }
}
