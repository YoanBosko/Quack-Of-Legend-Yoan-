using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;

    public bool moveLeft;
    public bool dead, doubleBone = false;
    public Animator animation;
    public GameObject bone;
    public UnityEvent feather;
    public UnityEvent featherExit;
    public UnityEvent feather2;
    public UnityEvent feather2Exit;
    public UnityEvent attackEvent;
    public UnityEvent passiveEvent;
    public UnityEvent knifeEvent;
    public UnityEvent boneEvent;
    private AttackScript attackScript;
    private PassiveScript passiveScript;
    private KnifeScript knifeScript;
    private GameState gameState;
    private PlayerStatus playerStatus;
    public int knifeUpgrade, boneUpgrade, featherUpgrade;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        attackScript = FindAnyObjectByType<AttackScript>();
        passiveScript = FindAnyObjectByType<PassiveScript>();
        knifeScript = FindAnyObjectByType<KnifeScript>();
        playerStatus = FindAnyObjectByType<PlayerStatus>();
        gameState = FindAnyObjectByType<GameState>();
        InvokeRepeating("UsePassive", 10f, playerStatus.haste);
        InvokeRepeating("UseAttack", 3f, playerStatus.haste * 0.3f - featherUpgrade);
    }

    void Update()
    {
        if (dead || gameState.paused || gameState.leveling)
        {
            rb.velocity = new Vector2(0, 0);
        }
        else
        {
            Walk();
        }
    }

    void Walk()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(moveX * playerStatus.spd, moveY * playerStatus.spd);

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
        passiveEvent?.Invoke();
        passiveScript.animation.SetBool("PassiveOn", true);
        StartCoroutine(DelayPassive());
    }
    IEnumerator DelayPassive()
    {
        yield return new WaitForSeconds(0.5945946f);
        passiveScript.animation.SetBool("PassiveOn", false);
    }
    public void RestartInvokeUseAttack()
    {
        CancelInvoke("UseAttack");
        InvokeRepeating("UseAttack", 3f, playerStatus.haste * 0.3f - featherUpgrade);
    }

    void UseAttack()
    {
        attackEvent?.Invoke();
        StartCoroutine(AttackAnimationDelay());
    }

    IEnumerator AttackAnimationDelay()
    {
        yield return new WaitForSeconds(0.06f);
        feather?.Invoke();
        feather2?.Invoke();
        // if (gameState.featherBuffCount > 2)
        // {
        //     feather2?.Invoke();
        // }
        StartCoroutine(DelayAttack());
    }
    IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(0.4827586f);
        featherExit?.Invoke();
        feather2Exit?.Invoke();
        // if (gameState.featherBuffCount > 2)
        // {
        //     feather2Exit?.Invoke();
        // }
    }



    public void KnifeGet()
    {
        CancelInvoke("UseKnife");
        InvokeRepeating("UseKnife", 5f, playerStatus.haste * 0.65f - knifeUpgrade);
    }
    void UseKnife()
    {
        knifeEvent?.Invoke();
        knifeScript.animation.SetBool("Knifing", true);
        StartCoroutine(DelayKnife());
    }
    IEnumerator DelayKnife()
    {
        yield return new WaitForSeconds(0.673913f);
        knifeScript.animation.SetBool("Knifing", false);
    }
    public void BoneGet()
    {
        CancelInvoke("UseBone");
        InvokeRepeating("UseBone", 5f, playerStatus.haste * 0.8f - boneUpgrade);
        if (doubleBone)
        {
            InvokeRepeating("UseBone", 1f, playerStatus.haste * 0.8f - boneUpgrade);
        }
    }
    void UseBone()
    {
        boneEvent?.Invoke();
        GameObject boneDrop = Instantiate(bone);
        boneDrop.transform.position = transform.position;
    }
}
