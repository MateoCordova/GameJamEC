using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navegador : MonoBehaviour
{
    private List<(int,int)> PosicionesJugador;
    private List<(int,int)> PosicionesComputador;
    public int puntajeJugador;
    public int puntajePC;

    void Start(){
        PosicionesJugador.Add((-300,-50));
    }
    public void Jugar(){
        SceneManager.LoadScene("Tablero");
    }
    public void Pregunta(){
        SceneManager.LoadScene("Principal", LoadSceneMode.Additive);
    }                  
}
