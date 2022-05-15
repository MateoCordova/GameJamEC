using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Question
{
    public Question(int id, string text, string background)
    {
        this.id = id;
        this.text = text;
        this.background = background;
        this.options = new List<Answer>();
    }
    public int id { get; set; }
    public string text { get; set; }
    public List<Answer> options { get; set; }
    public string background { get; set; }
}