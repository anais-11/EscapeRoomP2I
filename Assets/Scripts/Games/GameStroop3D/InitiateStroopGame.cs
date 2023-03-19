using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitiateStroopGame : MonoBehaviour
{
    public InventoryStroopGame inventory;
    public Animator animatorWelcome;
    public GameObject RedDiamPrefab;
    public GameObject BlueDiamPrefab;
    public GameObject GreenDiamPrefab;
    public GameObject YellowDiamPrefab;


    public List<Color> colorList;
    public List<TextColor> ListTexts = new List<TextColor>();

    public Terrain terrain;




    // Start is called before the first frame update
    void Start()
    {
        InitiateColor();
        inventory = FindObjectOfType<InventoryStroopGame>();
        terrain = FindObjectOfType<Terrain>();

        //Affiche la fenêtre de bienvenue du mini-jeu
        animatorWelcome.SetBool("isOpen", true);

        //On crée les diamants sur la map en définissant le nombre de diamants de chaque couleur que le joueur doit trouver
        InitiateColorToFind();


        //On créer les différents objet text qui apparaîtront à l'écran
        InitiateTextColor();


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitiateColor()
    {
        Color colorBlue = new Color32(232, 11, 11, 255);
        Color colorRed = new Color32(11, 111, 232, 255);
        Color colorYellow = new Color32(241, 211, 25, 255);
        Color colorGreen = new Color32(46, 196, 16, 255);
        colorList = new List<Color>() { colorRed, colorBlue, colorYellow, colorGreen };

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
        CreateDiams(inventory.nbBlue, BlueDiamPrefab,"bleu");

        inventory.nbYellow = Random.Range(1, 3);
        CreateDiams(inventory.nbYellow, YellowDiamPrefab, "jaune");

        inventory.nbRed = Random.Range(1, 3);
        CreateDiams(inventory.nbRed, RedDiamPrefab, "rouge");

        inventory.nbGreen = Random.Range(1, 3);
        CreateDiams(inventory.nbGreen, GreenDiamPrefab,"vert");



    }

    //Premet de créer un nombre de diamant en fonction d'un prefab
    public void CreateDiams(int nbDiams, GameObject prefabDiam, string color)
    {
        // Plage de coordonnées du terrain
        float xMin = 10;
        float xMax = 90;
        float zMin = 10;
        float zMax = 90;
        float yAboveTerrain = 3 / 2;

        //On ajoute une rotation car le prefab de base en possède une pour que le diamant soit vertical
        Quaternion rotation = Quaternion.Euler(-89.98f, 0f, 0f);

        //On crée le nombre de diamans bleus nécessaires + 3 en plus 
        for (int i = 0; i < nbDiams + 7; i++)
        {
            float x = Random.Range(xMin, xMax); // Coordonnée x aléatoire
            float z = Random.Range(zMin, zMax); // Coordonnée y aléatoire
            // Permet de récupérer la hauteur actuelle du terrain pour que le diamant ne soit pas enterré dans une coline
            float y = terrain.SampleHeight(new Vector3(x, 0, z)) + yAboveTerrain; 

            Vector3 position = new Vector3(x, y, z); // Création de la position aléatoire du diamant
            GameObject diams = Instantiate(prefabDiam, position, rotation); // Instantiation du préfab avec la position aléatoire

            //On ajoute le script diams au composant créé en définissant sa couleur
            diams.AddComponent<Diams>();
            diams.GetComponent<Diams>().color = color;

        }
    }

    //Initialise les textes affichés 
    public void InitiateTextColor()
    {
        int  id= 0;
        CreateText(inventory.nbBlue, "bleu",ref id) ;
        CreateText(inventory.nbGreen, "vert", ref id);
        CreateText(inventory.nbRed, "rouge", ref id);
        CreateText(inventory.nbYellow, "jaune", ref id);
        MixTextColor();

    }

    //Crée les objets text
    public void CreateText(int nbTextColor, string text,  ref int id)
    {

        //On créé le nombre de textes nécessaires correspondant à une couleur 
        for (int i =0; i<nbTextColor; i++)
        {
            //On définit une couleur aléatoire pour le texte
            int randomColor = Random.Range(0, 3);
            Color colorText = colorList[randomColor];

            //On instancie un objet text
            TextColor textColored = new TextColor(id, colorText, text);
            ListTexts.Add(textColored);
            id++;
        }
    }


    //Permet de mélanger aléatoirement l'odre des texts
    public void MixTextColor()
    {
        int n = ListTexts.Count;

        while (n > 1)
        {
            n--;
            int random = Random.Range(0, n + 1);
            TextColor value = ListTexts[random];
            
            ListTexts[random] = ListTexts[n];
            ListTexts[n] = value;
        }
    }
}

      


    

   
       
    

