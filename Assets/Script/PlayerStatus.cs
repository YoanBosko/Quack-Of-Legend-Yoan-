using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStatus : MonoBehaviour
{
    public int hp, maxHp, atk, expCap, exp;
    public float spd, haste;
    private EnemyStatus enemyStatus;
    private PlayerControl playerControl;
    public Animator animation;
    public UnityEvent playerDead;

    void Start()
    {
        playerControl = FindAnyObjectByType<PlayerControl>();
        enemyStatus = FindAnyObjectByType<EnemyStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0 && playerControl.dead == false)
        {
            playerControl.dead = true;
            playerControl.CancelInvoke("UsePassive");
            playerControl.CancelInvoke("UseAttack");
            animation.SetBool("Dead", true);
            StartCoroutine(DeadAnimationDelay());
        }
    }
    IEnumerator DeadAnimationDelay()
    {
        yield return new WaitForSeconds(0.7540984f);
        animation.SetBool("Dead", false);
        playerDead?.Invoke();
    }

    void OnTriggerEnter2D(Collider2D col2d)
    {
        if (col2d.tag == "Enemy" )
        {
            InvokeRepeating("TakeDamage", 0f, 0.4f);
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
