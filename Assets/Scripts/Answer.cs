using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Answer
{    
    public Answer(int id, string text, bool isCorrect)
    {
        this.id = id;
        this.text = text;
        this.isCorrect = isCorrect;
    }
    public int id { get; set; }
    public string text { get; set; }
    public bool isCorrect { get; set; }
    
}