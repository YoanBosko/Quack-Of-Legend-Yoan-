using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyChefM : MonoBehaviour
{
    Rigidbody2D rb;
    float hp, spd, atk;

    public bool moveLeft;
    public Animator animation;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hp = 30f;
        spd = 1f;
        atk = 5f;
    }

    void Update()
    {
        Walk();
    }

    void Walk()
    {
        // int Rando = Random.Range(1,2);
        float moveX;
        float moveY;
        rb.velocity = new Vector2(moveX * spd, moveY * spd);

        if (moveX != 0 || moveY != 0)
        {
            animation.SetBool("Moving", true);
        }
        else
        {
            animation.SetBool("Moving", false);
        }

        if (moveX > 0)
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            moveLeft = false;
        }
        else if (moveX < 0)
        {
            transform.localScale = new Vector3(-0.1f, 0.1f, 0.1f);
            moveLeft = true;
        }
    }
    
}
