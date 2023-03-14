using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameColorManager : MonoBehaviour
{
    
    public int combinationLength = 4;
    private List<int> combination = new List<int>();
    private List<int> playerCombination = new List<int>();
    public List<Color> colors;
    public Animator welcomeAnimator;
    public Animator failAnimator;
    public Animator successAnimator;
    public bool clicsActiveCubes = false;
    public InstanciateColorGame instanciateColorGame;


    public GameObject[,] cubes;
    public List<ColorClue> cluesCombination=new List<ColorClue>();
    public int rows = 4;
    public int cols = 4;
    public GameObject cubePrefab;


    //Appelé lors de la première pour présenter le jeu
    public void Start()
    {
        GameObject grille = GameObject.Find("GameColor");
        instanciateColorGame = grille.GetComponent<InstanciateColorGame>();
        instanciateColorGame.ShowGrille();

       

        //On ouvre la fenêtre de présentation du jeu
        welcomeAnimator.SetBool("WelcomeIsOpen", true);
    }

    //Permet de réinitialiser le jeu du joueur pour recommencer
    public void Replay()
    {
        //On ferme la fenêtre d'échec
        failAnimator.SetBool("FailIsOpen", false);

        //Permet de rénitialiser les cubes sélectionnés par le joueur
        playerCombination = new List<int>();

        ReloadColors();

        //On rend les clics sur les cubes possible
        clicsActiveCubes = true;

    }

    


    //Permet de fermer la fenêtre présentation du jeu
    public void CloseWelcome()
    {
        welcomeAnimator.SetBool("WelcomeIsOpen", false);
        clicsActiveCubes = true;
    }

    


    //Récupère les clics sur les cubes du joueur
    public void SetPlayerCombinaison(int id)
    {
        Debug.Log(id);
        playerCombination.Add(id);        

        //Une fois sa combinaison complétée
        if (playerCombination.Count == 4)
        {
            clicsActiveCubes = false;
            VerifyCombinaison();
        }
    }


    //Vérifie si la combinaison du joueur est la combinaison correcte
    public void VerifyCombinaison()
    {
        int mistakes = 0;
        for(int i=0; i < instanciateColorGame.combination.Count; i++)
        {
            if (instanciateColorGame.combination[i] != playerCombination[i])
            {
                mistakes++;
            }
        }

        //Ouvre une fenêtre d'échec
        if (mistakes != 0)
        {
            failAnimator.SetBool("FailIsOpen", true);
            


        }
        //Ouvre une fenêtre de succès
        else
        {
            InventoryManager.inventory.AddMap();
            successAnimator.SetBool("SuccessIsOpen", true);
        }
    }

    public void ReloadColors()
    {
        //Permet de rénitialiser les couleur d'origine des cubes (avant qu'ils soient cliqués)
        for (int i = 0; i < instanciateColorGame.cubes.GetLength(0); i++)
        {
            for (int j = 0; j < instanciateColorGame.cubes.GetLength(1); j++)
            {
                instanciateColorGame.cubes[i, j].GetComponent<Renderer>().material.color = instanciateColorGame.cubes[i, j].GetComponent<CubeScript>().originalColor;

            }
        }
    }

    public void ReturnToRoom()
    {
        ReloadColors();
        instanciateColorGame.HideGrille();
        SceneManager.LoadScene("EscapeRoom");
        

    }


    

    
}
