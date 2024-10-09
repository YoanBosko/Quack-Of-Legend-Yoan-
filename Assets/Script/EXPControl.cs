using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPControl : MonoBehaviour
{
    GameObject playerObject;

    public bool follow;

    float spd, x, y;
    void Start()
    {
        playerObject = GameObject.Find("Player");
        spd = 2f;
        x = Random.Range(-1, 2);
        y = Random.Range(-1, 2);
        InvokeRepeating("DragEXP", 0.1f, 0f);
    }

    void Update()
    {
        if (follow)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerObject.transform.position, spd * Time.deltaTime);
        }
    }

    void DragEXP()
    {
        spd *= Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + x, transform.position.y + y), spd);
        if (transform.position == new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z))
        {
            spd = 5f;
            CancelInvoke("DragEXP");
        }
    }

    void OnTriggerEnter2D(Collider2D col2d)
    {
        if (col2d.tag == "EXPRadius")
        {
            CancelInvoke("DragEXP");
            spd = 5f;
            follow = true;
        }
        if (col2d.tag == "Player")
        {
            CancelInvoke("DragEXP");
            Destroy(gameObject);
        }
    }
}
