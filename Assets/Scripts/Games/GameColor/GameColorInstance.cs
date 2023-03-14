using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameColorInstance : MonoBehaviour
{
    public static GameColorInstance instance;
    public static InstanciateColorGame gameColor;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            // Si une autre instance de cet objet existe déjà, détruire l'objet actuel
            Destroy(gameObject);
            return;
        }

        // Sinon, définir cette instance comme l'instance unique
        instance = this;
        DontDestroyOnLoad(gameObject);

        // Vérifier si une instance de l'inventaire existe déjà
        if (gameColor == null)
        {
            // Récupérer l'inventaire depuis l'objet Inventory dans la scène
            gameColor = FindObjectOfType<InstanciateColorGame>();

        }

    }
}
