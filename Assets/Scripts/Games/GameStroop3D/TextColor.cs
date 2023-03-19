using UnityEngine;
using System.Collections;

public class TextColor : MonoBehaviour
{
    public int id;
    public Color color;
    public string text;

    public TextColor(int id, Color color, string text)
    {
        this.id = id;
        this.color = color;
        this.text = text;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
