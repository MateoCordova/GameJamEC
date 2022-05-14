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
    public List<GameObject> Opciones;
    public float targetTime = 5.0f;
    public Question question;
    public GameObject Navegador;

    // Start is called before the first frame update
    void Start()
    {
        CierraOpciones();
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;
        timer.text = String.Format("{0:0}", targetTime);
        
        if (targetTime <= 0)
        {
            timer.text = "0";
        }
    }

    void CierraOpciones(){
        foreach(GameObject opcion in Opciones){
            opcion.transform.GetChild(2).gameObject.GetComponent<Button>().interactable = false;
        }
    }
    void RecibirRespuesta(int id){
        if(question.options[id].isCorrect){
            //Suma un punto a jugador
        } else {
            //Sum un punto a enemigo
        }
    }
}
