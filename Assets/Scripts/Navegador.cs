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

    public GameObject Jugador;
    public GameObject PC;
    public Button SiguentePregunta;
    void Start(){
        isPlaying = true;

        PosicionesJugador.Add((-786,-34));
        PosicionesComputador.Add((-786,-54));

        PosicionesJugador.Add((-740,-34));
        PosicionesComputador.Add((-740,-54));

        PosicionesJugador.Add((-700,-34));
        PosicionesComputador.Add((-700,-54));

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

    public void Volveraltablero(){
        SceneManager.UnloadSceneAsync("Principal");
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

    void Update() {
        Debug.Log(string.Format("Jugador {0:0}", Jugador.GetComponent<RectTransform>().position.x));
        Debug.Log(string.Format("Posision deseada {0:0}", PosicionesJugador[puntajeJugador].Item1));
        if(Jugador.transform.position.x < PosicionesJugador[puntajeJugador].Item1){
            //Jugador Move Animation
            MoveRight(Jugador.GetComponent<RectTransform>(),(float) PosicionesJugador[puntajeJugador].Item1);
            //Boton Disable
        }else {
            //Jugador Idle Animation
            //Boton enable
        }
        if(PosicionesComputador[puntajePC].Item1 > PC.transform.position.x){
            //PC Move Animation
            MoveRight(PC.GetComponent<RectTransform>(), (float) PosicionesComputador[puntajePC].Item1);
            //PC Move Animation
        } else {
            //PC Idle Animation
            //Boton enable
        }
        if(puntajePC == 9 ){
            SceneManager.LoadScene("Perdiste");
        }
        if(puntajeJugador == 9){
            SceneManager.LoadScene("Ganaste");
        }
    }
     public void MoveRight(RectTransform panel, float targetPosX)
     {
        StartCoroutine(Move(panel, new Vector2(targetPosX, 0)));
     }
 
     IEnumerator Move(RectTransform rt, Vector2 targetPos)
     {
         float step = 0;
         while (step < 1)
         {
             rt.offsetMin = Vector2.Lerp(rt.offsetMin, targetPos, step += Time.deltaTime);
             rt.offsetMax = Vector2.Lerp(rt.offsetMax, targetPos, step += Time.deltaTime);
             yield return new WaitForEndOfFrame();
         }
     }
}
