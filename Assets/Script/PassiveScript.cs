using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveScript : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator animation;
    GameObject playerObject;

    float spd = 100f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        playerObject = GameObject.Find("Player");
        transform.position = Vector3.MoveTowards(transform.position, playerObject.transform.position, spd * Time.deltaTime);
    }
}
