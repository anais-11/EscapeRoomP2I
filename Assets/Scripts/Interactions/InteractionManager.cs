using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour
{
    public TextMeshProUGUI nameObject;
    public TextMeshProUGUI action1;
    public TextMeshProUGUI action2;
    public Inventory inventory;
    public int rightChoice;
    public string result="Nothing";
    //Utiliser les animations d'ouverture et de fermeture de la fenêtre d'interaction créées sur l'interface
    public Animator animatorInteraction;
    public Animator wrongActionAnimator;
   


    public static InteractionManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance d'interactionManager dans la scène ");
            return;
        }
        instance = this;
        //Permet d'actualiser l'inventaire lorsque le joueur revient sur la scène
        inventory = FindObjectOfType<Inventory>();
        inventory.UpdateNbMap();

    }

    //Méthode qui récupère les informations de l'interaction avec un objet
    public void StartInteraction(Interaction interaction)
    {
        nameObject.text = interaction.NameUsed;
        action1.text = interaction.Actions[0];
        action2.text = interaction.Actions[1];
        rightChoice = interaction.RightChoice;
        result = interaction.Result.ToLower();
        //Ouverture de la fenêtre d'interaction
        animatorInteraction.SetBool("isOpen", true);

    }

    //On vérifie si le joueur sélectionne une touche du clavier
    void Update()
    {
        //Condition pour effectuer les actions seulement lorsque le joueur est en train de faire une interaction avec un objet
        if(nameObject.text != "Object"){
            //Si le joueur choisi une action (1 ou 2)
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.B))
            {
                
                
                //Fermeture de la fenêtre d'interaction
                EndInteraction();
                //Conversion de la lettre choisie en chiffre pour faciliter la suite
                int numberChoice;

                if (Input.GetKeyDown(KeyCode.A)){
                    numberChoice = 1;
                }
                else
                {
                    numberChoice = 2;
                }             
               
                //Si l'action choisie par le joueur n'amène à rien 
                if (numberChoice != rightChoice)
                {                    
                    //Affiche un panel indiquant que le choix effectué n'ammène à rien
                    wrongActionAnimator.SetBool("isOpen", true);
                }
                //Si l'action choisie par le joueur est une bonne action, 
                else
                {
                    ActionManager.instanceAction.SetObjectAction(nameObject.text,result);

                    
                }
            nameObject.text="Object";
            }
        }        
    }

    //Permet de fermer la fenêtre d'interaction
    public void EndInteraction()
    {
        animatorInteraction.SetBool("isOpen", false);
    }

    //Permet de fermer la fenêtre d'interaction d'une mauvaise action
    public void EndWrongActionInteraction()
    {
        wrongActionAnimator.SetBool("isOpen", false);
    }

    
}
