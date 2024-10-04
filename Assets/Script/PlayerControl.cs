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
    private AttackScript attackScript;
    private PassiveScript passiveScript;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        attackScript = FindAnyObjectByType<AttackScript>();
        passiveScript = FindAnyObjectByType<PassiveScript>();
        hp = 30;
        spd = 5f;
        atk = 5;
        haste = 10f;

        InvokeRepeating("UsePassive", 10f, 10f);
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

    void UsePassive()
    {
        passiveScript.animation.SetBool("PassiveOn", true);
        StartCoroutine(DelayPassive());
    }
    IEnumerator DelayPassive()
    {
        yield return new WaitForSeconds(0.5f);
        passiveScript.animation.SetBool("PassiveOn", false);
    }

    void UseAttack()
    {
        attackScript.animation.SetBool("Attacking", true);
        StartCoroutine(DelayAttack());
    }
    IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(0.5f);
        attackScript.animation.SetBool("Attacking", false);
    }
}
