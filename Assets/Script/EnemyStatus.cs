using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public int hp, atk;
    public float spd;

    public float timeCounter;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        if(timeCounter > 60f)
        {
            timeCounter -= 60f;
            hp += 5;
            atk += 1;
            spd += 0.5f;
        }
    }
}
