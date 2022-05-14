using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navegador : MonoBehaviour
{
    public int puntajeJugador;
    public int puntajePC;
    public void Jugar(){
        SceneManager.LoadScene("Tablero");
    }
    public void Pregunta(){
        SceneManager.LoadScene("Principal", LoadSceneMode.Additive);
    }                  
}
