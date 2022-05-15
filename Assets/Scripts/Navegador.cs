using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Navegador : MonoBehaviour
{
    private List<(double, double)> PosicionesJugador = new List<(double, double)>();
    private List<(double, double)> PosicionesComputador = new List<(double, double)>();
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
    void Start()
    {
        isPlaying = true;

        PosicionesJugador.Add((-780, -34));
        PosicionesComputador.Add((-780, -54));

        PosicionesJugador.Add((-630, -34));
        PosicionesComputador.Add((-630, -54));

        PosicionesJugador.Add((-480, -34));
        PosicionesComputador.Add((-480, -54));

        PosicionesJugador.Add((-330, -34));
        PosicionesComputador.Add((-330, -54));

        PosicionesJugador.Add((-200, -34));
        PosicionesComputador.Add((-200, -54));

        PosicionesJugador.Add((-70, 34));
        PosicionesComputador.Add((-70, 54));

        PosicionesJugador.Add((80, 34));
        PosicionesComputador.Add((60, 54));

        PosicionesJugador.Add((220, 34));
        PosicionesComputador.Add((200, 54));

        PosicionesJugador.Add((350, 34));
        PosicionesComputador.Add((330, 54));

        PosicionesJugador.Add((500, 34));
        PosicionesComputador.Add((470, 54));

        PosicionesJugador.Add((660, 34));
        PosicionesComputador.Add((600, 54));
    }
    public void Jugar()
    {
        SceneManager.LoadScene("Tablero");
    }
    public void Historia()
    {
        SceneManager.LoadScene("Historia");
    }
    public void Pregunta()
    {
        SceneManager.LoadScene("Principal", LoadSceneMode.Additive);
    }

    public void Volveraltablero()
    {
        SceneManager.UnloadSceneAsync("Principal");
    }
    public void Regresar()
    {
        SceneManager.LoadScene("Inicio");
    }
    public void Info()
    {
        SceneManager.LoadScene("Info");
    }
    public void PlayStopAudio()
    {
        if (isPlaying)
        {
            soundBtn.image.sprite = soundOff;
            isPlaying = false;
            audioSource.Pause();
        }
        else
        {
            soundBtn.image.sprite = soundOn;
            audioSource.Play();
            isPlaying = true;
        }
    }

    void Update()
    {
        if (SceneManager.sceneCount == 1)
        {
            if (Jugador.GetComponent<RectTransform>().anchoredPosition3D.x < PosicionesJugador[puntajeJugador].Item1)
            {
                //Jugador Move Animation
                Jugador.transform.Translate(0.5f, 0f, 0f);
                //Boton Disable
            }
            else
            {
                //Jugador Idle Animation
                //Boton Disable
                
            }
            if (PosicionesComputador[puntajePC].Item1 > PC.GetComponent<RectTransform>().anchoredPosition3D.x)
            {
                PC.transform.Translate(0.5f, 0f, 0f);
            }
            else
            {
                //Boton enable
            }
            if (puntajePC == 10)
            {
                StartCoroutine(Perdiste(5));
            }
            if (puntajeJugador == 10)
            {
                StartCoroutine(Ganaste(5));
            }
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
    IEnumerator Ganaste(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Ganaste");

    }
    IEnumerator Perdiste(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Perdiste");
    }
}
