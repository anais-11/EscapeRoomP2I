using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class StroopGameManager : MonoBehaviour
{
    public InitiateStroopGame initiateStroopGame;
    public InventoryStroopGame inventory;
    public int indexPlayer;
    public TextMeshProUGUI TextDisplayed;
    public HealthState healthState;
    public Animator GameOverAnimator;




    // Use this for initialization
    void Start()
    {
        indexPlayer = 0;
        initiateStroopGame = FindObjectOfType<InitiateStroopGame>();
        healthState = FindObjectOfType<HealthState>();
        TextDisplayed = GameObject.Find("ColorName").GetComponent<TextMeshProUGUI>();
        DisplayColorText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisplayColorText()
    {
        Debug.Log("ici");
        //On affiche le texte correspondant au nom de la couleur à trouver
        
        TextDisplayed.text = inventory.listText[indexPlayer].text;
        //On modifie la couleur du texte
        TextDisplayed.color = inventory.listText[indexPlayer].color;
    }

    public void VerifyOrderDiams(string colorDiams)
    {
        TextColor textReference = inventory.listText[indexPlayer];

        if (colorDiams == textReference.text)
        {
            Debug.Log("OK");
            indexPlayer++;
            DisplayColorText();
        }
        else
        {
            Debug.Log("Wrong !");
            healthState.WrongDiamants();

            if (healthState.alive==false)
            {
                GameOverAnimator.SetBool("isOpen", true);
                
            }

        }

    }

    public void Replay()
    {
        GameOverAnimator.SetBool("isOpen", false);
        healthState.RelivePlayer();
        initiateStroopGame.Replay();
    }

    public void BackToRoom()
    {
        SceneManager.LoadScene("EscapeRoom");
    }

    
}
