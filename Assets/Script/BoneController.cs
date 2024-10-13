using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneController : MonoBehaviour
{
    Vector2 min, max;
    Rigidbody2D rb;
    public bool stop;
    public float spd, hp;
    float x, y;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        min = Camera.main.ViewportToWorldPoint(new Vector2(0f, 0f));
        max = Camera.main.ViewportToWorldPoint(new Vector2(1f, 1f));
        x = Random.Range(min.x, max.x);
        y = Random.Range(min.y, max.y);
        StartCoroutine(StopBone());
        StartCoroutine(DelayBone());
    }

    IEnumerator DelayBone()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);

    }
    IEnumerator StopBone()
    {
        yield return new WaitForSeconds(0.5f);
        stop = true;

    }
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
        if (stop)
        {
            rb.velocity = new Vector3(0, 0);
            rb.gravityScale = 0;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + x, transform.position.y + y, 10), spd * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D col2d)
    {
        if (col2d.tag == "Enemy")
        {
            InvokeRepeating("TakeDamage", 0f, 1f);
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
        hp -= 1f;
    }
}
