using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEditor;

public class EnemyChefM : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject playerObject;

    float hp, spd, atk;
    public bool moveLeft;
    public Animator animation;
    float distance;
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
}
