using System.Collections.Generic;
using UnityEngine;



public class InteractionTrigger : MonoBehaviour
{
    private Collision2D currentCollision;
    public bool isInCollision;
    public List<Interaction> interactions = new List<Interaction>();


    private void Start()
    {
        CreateInteractionObject();
    }
    // Update is called once per frame
    void Update()
    {
        if (isInCollision && Input.GetKeyDown(KeyCode.E))
        {
            TriggerInteraction();
        }
    }

    //Permet de savoir si le joueur est en collision avec l'objet
    private void OnCollisionEnter2D(Collision2D infoCollision)
    {
        currentCollision = infoCollision;
        Debug.Log(currentCollision.gameObject.name);
        if (InteractionObjectExist(currentCollision.gameObject.name))
        {
            isInCollision = true;
        }



    }
    private void OnCollisionExit2D(Collision2D infoCollision)
    {
        isInCollision = false;
    }

    //Permet d'appeler la méthode du script InteractionManger pour ouvrir l'interaction
    public void TriggerInteraction()
    {
        Interaction interaction;
        string nameObject = currentCollision.gameObject.name;

        interaction = FindInteraction(nameObject);
        InteractionManager.instance.StartInteraction(interaction);
       


    }

    //Permet de créer les interactions possibles avec les objet dans la salle
    public void CreateInteractionObject()
    {
        string[] actionsPlant = new string[] { "Regarder sous le pot", "Creuser dans la terre" };
        Interaction plantRight = new Interaction("plantRight", "Plante", actionsPlant, 2, "clue");
        interactions.Add(plantRight);

        string[] actionsLibrary = new string[] { "Ouvrir le libre bleu", "Ouvrir le livre vert" };
        Interaction library = new Interaction("libraryLeft", "Bibliothèque", actionsLibrary, 1, "clue");
        interactions.Add(library);

        string[] actionsSofa = new string[] { "Regarder entre les cousin", "Regarder sous le canapé" };
        Interaction sofa = new Interaction("sofaRight", "Canapé", actionsSofa, 2, "game");
        interactions.Add(sofa);

        string[] actionBed = new string[] { "Regarder sous l'oreiller", "Secouer les draps" };
        Interaction bed = new Interaction("Bed", "Lit", actionBed, 2, "clue");
        interactions.Add(bed);

        string[] actionLamp = new string[] { "Allumer la lampe", "Regarder sous la lampe" };
        Interaction yellowLampLeft = new Interaction("yellowLampLeft", "Lampe", actionLamp, 1, "clue");
        interactions.Add(yellowLampLeft);

        string[] actionTable = new string[] { "Regarder sous la table", "Déplacer la table" };
        Interaction tvPlace = new Interaction("tvPlace", "table", actionTable, 1, "clue");
        interactions.Add(tvPlace);
    }

    //Renvoie une interaction
    public Interaction FindInteraction(string name)
    {
        Interaction interactionToFind = null;
        foreach (Interaction interaction in interactions)
        {
            if (interaction.NameObject == name)
            {
                interactionToFind = interaction;
            }
        }
        return interactionToFind;
    }

    //Renvoie si l'interaction existe ou non
    public bool InteractionObjectExist(string name)
    {
        bool result = false;
        foreach (Interaction interaction in interactions)
        {
            if (interaction.NameObject == name)
            {
                Debug.Log(interaction.NameObject);
                result = true;
            }
        }
        Debug.Log(result);
        return result;
    }
}
