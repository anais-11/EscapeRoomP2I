using UnityEngine;
using System.Collections;

public class Diams : MonoBehaviour
{
    public int id { get; set; }
    public string color { get; set; }
    public bool isInCollision;
    StroopGameManager gameManager;

    // Use this for initialization
    void Start()
    {
        gameManager = FindObjectOfType<StroopGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInCollision && Input.GetKeyDown(KeyCode.E))
        {
            gameObject.SetActive(false);
            VerifyDiamsColor();


        }
    }

    private void OnCollisionEnter(Collision infoCollision)
    {
        isInCollision = true;

    }
    private void OnCollisionExit(Collision infoCollision)
    {
        isInCollision = false;
    }

    public void VerifyDiamsColor()
    {
        gameManager.VerifyOrderDiams(color);
    }
}
