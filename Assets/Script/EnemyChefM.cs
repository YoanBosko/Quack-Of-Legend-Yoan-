using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyChefM : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject playerObject;
    public UnityEvent hitEvent;

    int hp;

    public bool moveLeft;
    public bool dead;
    public Animator animation;
    private PlayerStatus playerStatus;
    private EnemyStatus enemyStatus;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerStatus = FindAnyObjectByType<PlayerStatus>();
        enemyStatus = FindAnyObjectByType<EnemyStatus>();
        hp = enemyStatus.hp;
    }

    void Update()
    {
        Walk();
        if (hp <= 0 && dead == false)
        {
            dead = true;
            animation.SetTrigger("Dead");
            StartCoroutine(DelayDead());
        }
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
            if (dead != true)
            {
                transform.position = Vector3.MoveTowards(transform.position, playerObject.transform.position, enemyStatus.spd * Time.deltaTime);
                animation.SetBool("Moving", true);
            }
            else
            {
                animation.SetBool("Moving", false);
            }
        }

    }

    IEnumerator DelayDead()
    {
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col2d)
    {
        if (col2d.tag == "Attack")
        {
            hp -= playerStatus.atk;
            hitEvent?.Invoke();
        }
        if (col2d.tag == "Passive")
        {
            hp -= playerStatus.atk / 2;
            hitEvent?.Invoke();
        }
    }

    // void OnCollisionEnter2D(Collision2D col)
    // {
    //     if (col.collider.CompareTag("Player"))
    //     {
    //         Col2d.isTrigger = true;
    //     }
    // }

    // void OnTriggerExit2D(Collider2D col)
    // {
    //     if (col.tag == "Player")
    //     {
    //         Col2d.isTrigger = false;
    //     }
    // }
}
