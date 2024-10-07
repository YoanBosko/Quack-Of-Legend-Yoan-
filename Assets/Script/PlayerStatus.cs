using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int hp, atk;
    public float spd, haste;
    private EnemyStatus enemyStatus;

    void Start()
    {
        enemyStatus = FindAnyObjectByType<EnemyStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col2d)
    {
        if (col2d.tag == "Enemy")
        {
            InvokeRepeating("TakeDamage", 0f, 0.1f);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            CancelInvoke("TakeDamage");
        }
    }
    void TakeDamage()
    {
        hp -= enemyStatus.atk;
    }
}
