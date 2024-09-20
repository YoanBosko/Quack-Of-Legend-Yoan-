using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;
    float HP, SPD, ATK, HASTE;

    public bool MoveLeft;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        HP = 30f;
        SPD = 5f;
        ATK = 5f;
        HASTE = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }

    void Walk()
    {
        float MoveX = Input.GetAxis("Horizontal");
        float MoveY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(MoveX * SPD, MoveY * SPD);

        if (MoveX > 0)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            MoveLeft = false;
        }
        else if (MoveX < 0)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            MoveLeft = true;
        }
    }
}
