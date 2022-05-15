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

    // Start is called before the first frame update
    void Start()
    {
        question = GameObject.Find("Database").GetComponent<getData>().getQuestion();
        pregunta.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = question.text;
        for(int i = 0; i < 4 ; i++){
            Opciones[i].transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = question.options[i].text;
        }
        Debug.Log(question.background);
        fondo.texture = texturas[int.Parse(question.background)];
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;
        timer.text = String.Format("{0:0}", targetTime);
        
        if (targetTime <= 0)
        {
            timer.text = "0";
            CierraOpciones();
            GameObject.Find("Control de juego").GetComponent<Navegador>().puntajePC ++;
            StartCoroutine(VolverATablero(5));
        }
    }

    void CierraOpciones(){
        foreach(GameObject opcion in Opciones){
            opcion.transform.GetChild(2).gameObject.GetComponent<Button>().interactable = false;
        }
    }
    public void RecibirRespuesta(int id){
        if(question.options[id].isCorrect){
            GameObject.Find("Control de juego").GetComponent<Navegador>().puntajeJugador ++;
            //Sonido Acierto
            StartCoroutine(VolverATablero(5));
            
        } else {
            GameObject.Find("Control de juego").GetComponent<Navegador>().puntajePC ++;
            //Sonido Derrota
            StartCoroutine(VolverATablero(5));
        }
    }

    IEnumerator VolverATablero(float time)
    {
        yield return new WaitForSeconds(time);
        GameObject.Find("Control de juego").GetComponent<Navegador>().Volveraltablero();
    }
}
