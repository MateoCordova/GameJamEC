using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navegador : MonoBehaviour
{
    private List<(double,double)> PosicionesJugador;
    private List<(double,double)> PosicionesComputador;
    public int puntajeJugador;
    public int puntajePC;

    void Start(){
        PosicionesJugador.Add((-351,-34));
        PosicionesComputador.Add((-351,-54));

        PosicionesJugador.Add((-298,-34));
        PosicionesComputador.Add((-298,-54));

        PosicionesJugador.Add((-232,-34));
        PosicionesComputador.Add((-232,-54));

        PosicionesJugador.Add((-167,-34));
        PosicionesComputador.Add((-167,-54));
        
        PosicionesJugador.Add((-38.5,-34));
        PosicionesComputador.Add((-38.5,-54));

        PosicionesJugador.Add((26.5, 34));
        PosicionesComputador.Add((26.5, 54));

        PosicionesJugador.Add((92.2, 34));
        PosicionesComputador.Add((92.2, 54));

        PosicionesJugador.Add((156.2, 34));
        PosicionesComputador.Add((156.2, 54));

        PosicionesJugador.Add((221.8, 34));
        PosicionesComputador.Add((221.8, 54));

        PosicionesJugador.Add((285.1, 34));
        PosicionesComputador.Add((285.1, 54));

        PosicionesJugador.Add((350.2, 34));
        PosicionesComputador.Add((350.2, 54));
    }
    public void Jugar(){
        SceneManager.LoadScene("Tablero");
    }
    public void Pregunta(){
        SceneManager.LoadScene("Principal", LoadSceneMode.Additive);
    }                  
}
