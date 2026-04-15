using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class playermove : MonoBehaviour
{
    public Image barradevid;
    Scene scene;
    private float speed = 3f;
    private  Rigidbody2D playerRB;
    private Vector2 moveImput;
    private Animator playerAnimator;
    private float vida = 3;
    private float tiempo;
    private bool vid = true;
    
    private float vidatotal = 3;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + scene.name + "'.");
    }

    // Update is called once per frame
    void Update()
    {
        barradevid.fillAmount = vida / vidatotal;
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveImput = new Vector2(moveX,moveY).normalized;
        playerAnimator.SetFloat("Horizontal",moveX);
        playerAnimator.SetFloat("Vertical",moveY);
        playerAnimator.SetFloat("Speed",moveImput.sqrMagnitude);
        if(vid==false){
          tiempo += 1 * Time.deltaTime;
        if(tiempo>=3){
            vid =true;
            tiempo=0;
        }
         }
         if(vida<=0){
             
             string levelname = scene.name; 
            SceneManager.LoadScene(3);
                Destroy(gameObject);
            }
            if (Input.GetKey("escape"))
        {
            Debug.Log("scape");
            Application.Quit();
        }
    }
    private void FixedUpdate(){
        playerRB.MovePosition(playerRB.position + moveImput * speed * Time.fixedDeltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision){
        //Debug.Log(collision.gameObject.name);
        
         if(collision.gameObject.tag == "velocidad"){
         speed += 1f;
         }
         if(vid==true){
          if(collision.gameObject.tag == "Enemigo"||collision.gameObject.tag == "dano"){
         vida--;
         vid=false; 
         }
         }
         if(collision.gameObject.tag == "vida"){
            if(vida<3){
            vida++;
            }
         }
         
         
    }
}
