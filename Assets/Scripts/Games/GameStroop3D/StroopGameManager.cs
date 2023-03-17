using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StroopGameManager : MonoBehaviour
{
    public InventoryStroopGame inventory;
    public Animator animatorWelcome;
    public GameObject RedDiamPrefab;
    public GameObject BlueDiamPrefab;
    public GameObject GreenDiamPrefab;
    public GameObject YellowDiamPrefab;
    public Terrain terrain;




    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<InventoryStroopGame>();
        terrain = FindObjectOfType<Terrain>();
        //Affiche la fenêtre de bienvenue du mini-jeu
        animatorWelcome.SetBool("isOpen", true);
        InitiateColorToFind();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Permet de fermer la fenêtre de bienvenue
    public void CloseWelcome()
    {
        animatorWelcome.SetBool("isOpen", false);
    }

    //Permet de retourner vers la salle principale
    public void ReturnToRoom()
    {
        SceneManager.LoadScene("escapeRoom");
    }

    public void InitiateColorToFind()
    {
        //On instancie combien de texte d'une couleur spécifique le joueur devra trouver
        //Ex : le joueur devra trouver entre 1 et 3 diamants de couleur bleu
        inventory.nbBlue = Random.Range(1, 3);
        //On crée le nombre de diamants nécessaires
        CreateDiams(inventory.nbBlue, BlueDiamPrefab);

        inventory.nbYellow = Random.Range(1, 3);
        CreateDiams(inventory.nbYellow, YellowDiamPrefab);

        inventory.nbRed = Random.Range(1, 3);
        CreateDiams(inventory.nbRed, RedDiamPrefab);

        inventory.nbGreen = Random.Range(1, 3);
        CreateDiams(inventory.nbGreen, GreenDiamPrefab);



    }

    //Premet de créer un nombre de diamant en fonction d'un prefab
    public void CreateDiams(int nbDiams, GameObject prefabDiam)
    {
        // Plage de coordonnées
        float xMin = 10;
        float xMax = 90;
        float zMin = 10;
        float zMax = 90;
        float yAboveTerrain = 3 / 2;

        //On ajoute une rotation car le prefab de base en possède une pour que le diamant soit droit
        Quaternion rotation = Quaternion.Euler(-89.98f, 0f, 0f);

        //On crée le nombre de diamans bleus nécessaires + 3 en plus 
        for (int i = 0; i < nbDiams + 7; i++)
        {
            float x = Random.Range(xMin, xMax); // Coordonnée x aléatoire
            float z = Random.Range(zMin, zMax); // Coordonnée y aléatoire
            float y = terrain.SampleHeight(new Vector3(x, 0, z)) + yAboveTerrain; // Permet de récupérer la hauteur actuelle du terrain pour que le diamant ne soit pas enterré dans une coline

            Vector3 position = new Vector3(x, y, z); // Création de la position aléatoire
            Instantiate(prefabDiam, position, rotation); // Instantiation du préfab avec la position aléatoire
        }
    }
}

      


    

   
       
    

