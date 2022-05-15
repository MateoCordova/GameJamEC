using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Controlador : MonoBehaviour
{
    public TMP_Text timer;
    public GameObject pregunta;
    public RawImage fondo;
    public List<GameObject> Opciones;
    public float targetTime = 5.0f;
    private Question question;
    public GameObject Navegador;
    public List<Texture> texturas;
    private bool tiempo;
    private int puntuaPC;
    // Start is called before the first frame update
    
    //AUDIO
    public AudioClip clipCorrecto;
    public AudioClip clipIncorrecto;
    public AudioSource audioSource;
    public float volume = 0.5f;


    void Start()
    {
        tiempo = true;

        question = GameObject.Find("Database").GetComponent<getData>().getQuestion();
        pregunta.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = question.text;
        for(int i = 0; i < 4 ; i++){
            Opciones[i].transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = question.options[i].text;
        }
        Debug.Log(question.background);
        fondo.texture = texturas[int.Parse(question.background)-1];
        puntuaPC = GameObject.Find("Control de juego").GetComponent<Navegador>().puntajePC;
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;
        if (tiempo) {
            timer.text = String.Format("{0:0}", targetTime);
        }

        if (targetTime <= 0)
        {
            timer.text = "0";
            CierraOpciones();
            GameObject.Find("Control de juego").GetComponent<Navegador>().puntajePC = puntuaPC + 2;
            audioSource.PlayOneShot(clipIncorrecto, volume);
            StartCoroutine(VolverATablero(3));
        }
    }

    void CierraOpciones(){
        foreach(GameObject opcion in Opciones){
            opcion.transform.GetChild(2).gameObject.GetComponent<Button>().interactable = false;
        }
    }
    public void RecibirRespuesta(int id){
        tiempo = false;
        CierraOpciones();
        if(question.options[id].isCorrect){
            GameObject.Find("Control de juego").GetComponent<Navegador>().puntajeJugador += 2;
            audioSource.PlayOneShot(clipCorrecto, volume);
            StartCoroutine(VolverATablero(3));
            
        } else {
            GameObject.Find("Control de juego").GetComponent<Navegador>().puntajePC += 2;
            audioSource.PlayOneShot(clipIncorrecto, volume);
            StartCoroutine(VolverATablero(3));
        }
    }

    IEnumerator VolverATablero(float time)
    {
        yield return new WaitForSeconds(time);
        GameObject.Find("Control de juego").GetComponent<Navegador>().Volveraltablero();
    }
}
