using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator animation;
    GameObject attackPosition;
    
    float spd = 100f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        attackPosition = GameObject.Find("Player Attack Pos");
        transform.position = Vector3.MoveTowards(transform.position, attackPosition.transform.position, spd * Time.deltaTime);
    }
}
