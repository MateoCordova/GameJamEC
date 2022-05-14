using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Question : MonoBehaviour
{
    public string text { get; set; }
    public List<Answer> options { get; set; }
    public string background { get; set; }
}