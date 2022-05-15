using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Regresar : MonoBehaviour
{
    void Start()
    {
        
    }
    public void Volver()
    {
        SceneManager.LoadScene("Inicio");
    }
    

    void Update()
    {

    }
}
