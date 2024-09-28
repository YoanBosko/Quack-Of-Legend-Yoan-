using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    float HP, SPD, ATK, HASTE;

    public bool MoveLeft;
    public Animator animation;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        HP = 30f;
        SPD = 5f;
        ATK = 5f;
        HASTE = 10f;
    }

    void Update()
    {
        Walk();
    }

    void Walk()
    {
        float MoveX = Input.GetAxis("Horizontal");
        float MoveY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(MoveX * SPD, MoveY * SPD);

        if (MoveX != 0 || MoveY != 0)
        {
            animation.SetBool("Moving", true);
        }
        else
        {
            animation.SetBool("Moving", false);
        }

        if (MoveX > 0)
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            MoveLeft = false;
        }
        else if (MoveX < 0)
        {
            transform.localScale = new Vector3(-0.1f, 0.1f, 0.1f);
            MoveLeft = true;
        }
    }
}
