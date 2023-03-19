using UnityEngine;
using System.Collections;

public class Diams : MonoBehaviour
{
    public int id { get; set; }
    public string color { get; set; }
    public bool isInCollision;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isInCollision && Input.GetKeyDown(KeyCode.Return))
        {
            gameObject.SetActive(false);

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
}
