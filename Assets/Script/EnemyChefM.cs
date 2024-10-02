using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyChefM : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D Col2d;
    GameObject playerObject;

    int hp, atk;
    float spd;
    public bool moveLeft;
    public Animator animation;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Col2d = GetComponent<Collider2D>();
        hp = 30;
        spd = 1f;
        atk = 5;
    }

    void Update()
    {
        Walk();
        // int Rando = Random.Range(1,2);
    }

    void Walk()
    {
        playerObject = GameObject.Find("Player");
        if (playerObject != null)
        {
            if (playerObject.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                moveLeft = false;
            }
            else if (playerObject.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                moveLeft = true;
            }

            transform.position = Vector3.MoveTowards(transform.position, playerObject.transform.position, spd * Time.deltaTime);
            animation.SetBool("Moving", true);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            Col2d.isTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Col2d.isTrigger = false;
        }
    }
}
