using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void jugar()
    {
        SceneManager.LoadScene(8);
    }
    public void reglas()
    {
        SceneManager.LoadScene(7);
    }
    public void salir()
    {
        Application.Quit();
    }
}
