using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Navegador : MonoBehaviour
{
    private List<(double,double)> PosicionesJugador = new List<(double, double)>();
    private List<(double,double)> PosicionesComputador = new List<(double, double)>();
    public int puntajeJugador;
    public int puntajePC;
    public AudioSource audioSource;
    public Button soundBtn;
    public Sprite soundOn;
    public Sprite soundOff;
    private bool isPlaying;

    void Start(){
        isPlaying = true;

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
    public void Regresar(){
        SceneManager.LoadScene("Inicio");
    }
    public void Info(){
        SceneManager.LoadScene("Info");
    }
    public void PlayStopAudio(){
        if (isPlaying){
            soundBtn.image.sprite = soundOff;
            isPlaying = false;
            audioSource.Pause();
        } else {
            soundBtn.image.sprite = soundOn;
            audioSource.Play();
            isPlaying = true;
        }
    }
}
