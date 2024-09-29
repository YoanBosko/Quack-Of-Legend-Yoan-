using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject playerObject;
    private PlayerControl playerControl;
    float spd;
    public bool moveLeft;
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        spd = 5f;
    }
    void Update()
    {
        playerObject = GameObject.Find("Player");
        playerControl = FindAnyObjectByType<PlayerControl>();
        if (playerObject != null)
        {
            if (playerControl.moveLeft == false)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                moveLeft = false;
            }
            else if (playerControl.moveLeft == true)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                moveLeft = true;
            }

            transform.position = Vector3.MoveTowards(transform.position, playerObject.transform.position, spd * Time.deltaTime);
        }
        Invoke("DestroyObject", 0.383f);
    }
    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
