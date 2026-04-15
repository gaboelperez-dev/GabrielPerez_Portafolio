using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firepoint;
    public GameObject prefabshot;
    public Camera cam;

    public float fuerzadisparo =20f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }
    void Shoot(){
        Vector2 mousePos=cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos- new Vector2(firepoint.position.x,firepoint.position.y);
        float angle = Mathf.Atan2(lookDir.y,lookDir.x)*Mathf.Rad2Deg-90f;
        GameObject bulled = Instantiate(prefabshot,firepoint.position,firepoint.rotation);
        Rigidbody2D rb=bulled.GetComponent<Rigidbody2D>();
        bulled.transform.rotation=Quaternion.Euler(0,0,angle);
        rb.AddForce(bulled.transform.up*fuerzadisparo, ForceMode2D.Impulse);
    }
    void OnCollisionEnter2D(Collision2D prefabshot){
        //Debug.Log(prefabshot.gameObject.name);
    }
}
