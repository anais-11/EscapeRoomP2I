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
    public bool arcadeClueFind = false;

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
            case "arcade":
                ArcadeAction();
                break;



        }

    }

    public void ArcadeAction()
    {
        SceneManager.LoadScene("Stroop3D");
    }

    public void ArmoireActions(ActionManager instance)
    {
        //Récupération et affichage des indices des 4 cubes de couleurs
        for (int i = 1; i <= 4; i++)
        {
            // Récupération de l'indice du Cube1
            string cubeName = "Cube" + i.ToString();

            // Recherche du GameObject avec le nom généré
            GameObject cubeObject = GameObject.Find(cubeName);

            // Récupération des composants Image et TextMeshProUGUI
            Image cubeImage = cubeObject.GetComponent<Image>();
            TextMeshProUGUI textMeshProUGUI = cubeObject.transform.Find("TextCube" + i.ToString()).GetComponent<TextMeshProUGUI>();

            // Mise à jour de la couleur de l'image et du texte
            cubeImage.color = InventoryManager.inventory.clueColorList[i - 1].Color;
            textMeshProUGUI.text = i.ToString();
        }

     


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
