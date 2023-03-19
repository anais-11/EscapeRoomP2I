using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryStroopGame : MonoBehaviour
{
    //nombre de diamants que le joueur doit rammasser
    public int nbRed { get; set; }
    public int nbGreen { get; set; }
    public int nbBlue { get; set; }
    public int nbYellow { get; set; }
    public int nbLives { get; set; }

    public List<TextColor> listText;

    //nombre 
    

    // Start is called before the first frame update
    void Start()
    {
        nbLives = 4;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
