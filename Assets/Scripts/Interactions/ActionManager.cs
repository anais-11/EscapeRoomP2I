using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ActionManager : MonoBehaviour
{
    public string nameObject;
    public string result;
    public Animator colorClueAnimator;
    public Animator uniqueColorClue;
    public bool isOpen = false;
    public static ActionManager instanceAction;

    public bool armoireClueFind = false;
    public bool plantClueFind = false;
    public bool bedClueFind = false;
    public bool lampClueFind = false;
    public bool tableClueFind = false;

    private void Awake()
    {
        if (instanceAction != null)
        {
            Debug.LogWarning("Il y a plus d'une instance d'actionManager dans la scène ");
            return;
        }
        instanceAction = this;
    }

    public void SetObjectAction(string name, string result)
    {
        nameObject = name.ToLower();
        this.result = result;
        ObjectAction(instanceAction);


    }

    public void ObjectAction(ActionManager instance)
    {
        string name = instance.nameObject;
        switch (name)
        {
            case "bibliothèque":
                ArmoireActions(instance);
                break;
            case "canapé":
                SofaRightActions(instance);                
                break;
            case "plante" or "lit" or "table" or "lampe":
                ShowClueColor(name);
                break;


        }

    }

    public void ArmoireActions(ActionManager instance)
    {

        //Récupération et affichage de l'indice du Cube1
        Image Cube1 = GameObject.Find("Cube1").GetComponent<Image>();    
        TextMeshProUGUI TextCube1 = GameObject.Find("TextCube1").GetComponent<TextMeshProUGUI>();      
        Cube1.color = InventoryManager.inventory.clueColorList[0].Color;
        TextCube1.text = "1";

        //Récupération et affichage de l'indice du Cube1
        Image Cube2 = GameObject.Find("Cube2").GetComponent<Image>();
        TextMeshProUGUI TextCube2 = GameObject.Find("TextCube2").GetComponent<TextMeshProUGUI>();
        Cube2.color = InventoryManager.inventory.clueColorList[1].Color;
        TextCube2.text = "2";

        //Récupération et affichage de l'indice du Cube1
        Image Cube3 = GameObject.Find("Cube3").GetComponent<Image>();
        TextMeshProUGUI TextCube3 = GameObject.Find("TextCube3").GetComponent<TextMeshProUGUI>();
        Cube3.color = InventoryManager.inventory.clueColorList[2].Color;
        TextCube3.text = "3";

        //Récupération et affichage de l'indice du Cube1
        Image Cube4 = GameObject.Find("Cube4").GetComponent<Image>();
        TextMeshProUGUI TextCube4 = GameObject.Find("TextCube4").GetComponent<TextMeshProUGUI>();
        Cube4.color = InventoryManager.inventory.clueColorList[3].Color;
        TextCube4.text = "4";



        if (!isOpen){
            if (instance.result == "clue")
            {
                colorClueAnimator.SetBool("clueIsOpen", true);

                if (!armoireClueFind)
                {
                    Inventory.instance.AddClue();
                    armoireClueFind=true;
                }
            }
            isOpen = true;
        }
        else
        {
            colorClueAnimator.SetBool("clueIsOpen", false);
            isOpen = false;
        }
    }

    public void SofaRightActions(ActionManager instance)
    {
        Debug.Log("ok je suis au canap");
        if (instance.result == "game")
        {
            SceneManager.LoadScene("ColorGame");
        }

    }

    public void ShowClueColor(string name)
    {
        Debug.Log("lit1");
        int index=0;
        bool clueFind=false;
       
        switch (name)
        {
            case "plante":
                index = 0;                
                clueFind = plantClueFind;
                plantClueFind = true;
                break;

            case "lit":
                index = 1;                
                clueFind = bedClueFind;
                bedClueFind = true;
                break;

            case "lampe":
                index = 2;
                clueFind = lampClueFind;
                lampClueFind = true;
                break;

            case "table":
                index = 3;
                clueFind = tableClueFind;
                tableClueFind = true;
                break;
        }

        //On récupère le cube indice à modifier
         
        Image cube = GameObject.Find("cubeClue").GetComponent<Image>();

        //On récupère le texte du cube indice à modifier
       
        TextMeshProUGUI clueText = GameObject.Find("textClue").GetComponent<TextMeshProUGUI>();
        
        //On accède à la couleur du cube et on modifie sa couleur avec celle du cube référent
     
        cube.color = InventoryManager.inventory.clueColorList[index].Color;


        //On modifie le texte du cube indice avec la position du cube référent
        //On fait appel à InventoryManager qui permet de d'accéder à l'instance unique de l'inventaire 
        clueText.text = InventoryManager.inventory.clueColorList[index].RowAndCol;

        if (!isOpen)
        {
            Debug.Log("lit2");
            uniqueColorClue.SetBool("isOpen", true);

            if (!clueFind)
            {
                Inventory.instance.AddClue();                
            }

            isOpen = true;
        }
        else
        {
            uniqueColorClue.SetBool("isOpen", false);
            isOpen = false;
        }
    }

}
