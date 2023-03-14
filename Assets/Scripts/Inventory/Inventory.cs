using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public TextMeshProUGUI nbClues;
    public int countClues=0;
    public TextMeshProUGUI nbMaps;
    public int countMaps=0;
    public static Inventory instance;
    public List<ColorClue> clueColorList = new List<ColorClue>();


    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogWarning("Il y a plus d'une instance de l'inventaire dans la scène");
            Destroy(gameObject);            

            return;
        }
        instance = this;

        DontDestroyOnLoad(gameObject);

       
    }
    public void UpdateNbMap()
    {
        nbMaps = GameObject.Find("nbMaps").GetComponent<TextMeshProUGUI>();
        nbMaps.text = countMaps.ToString();
    }



    public void AddClue()
    {
        countClues += 1;
        
        nbClues.text = countClues.ToString();
        
    }

    public void AddMap()
    {
        countMaps += 1;
        UpdateNbMap();
        
    }

   




}
