using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;

    int hp, atk;
    float spd, haste;
    public bool moveLeft;
    public Animator animation;
    public GameObject skill1;
    public GameObject attack;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hp = 30;
        spd = 5f;
        atk = 5;
        haste = 10f;

        InvokeRepeating("UseSkill1", 10f, 10f);
        InvokeRepeating("UseAttack", 3f, 3f);
    }

    void Update()
    {
        Walk();
    }

    void Walk()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
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
            transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);
            moveLeft = false;
        }
        else if (moveX < 0)
        {
            transform.localScale = new Vector3(-0.06f, 0.06f, 0.06f);
            moveLeft = true;
        }
    }

    void UseSkill1()
    {
        GameObject Skill1 = (GameObject)Instantiate(skill1);
        Skill1.transform.position = transform.position;
    }
    void UseAttack()
    {
        GameObject Attack = (GameObject)Instantiate(attack);
        Attack.transform.position = transform.position;
    }
}
