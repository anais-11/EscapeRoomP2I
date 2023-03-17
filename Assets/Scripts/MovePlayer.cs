using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 5f;

    const int RIGHT = 1;
    const int LEFT = -1;
    const int UP = 2;
    const int DOWN = -2;
    private Animator animator;
    public Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame


    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (Mathf.Abs(horizontal) > Mathf.Abs(vertical))
            {
                // Move left or right
                animator.SetInteger("Direction", (int)horizontal);
            }
            else
            {
                // Move up or down
                animator.SetInteger("Direction", (int)vertical * 2);
            }
            Vector2 movement = new Vector2(horizontal, vertical);
            rigidBody.MovePosition(rigidBody.position + movement * speed * Time.fixedDeltaTime);
        }
        else
        {
            animator.SetInteger("Direction", 0);
        }

    }

}

