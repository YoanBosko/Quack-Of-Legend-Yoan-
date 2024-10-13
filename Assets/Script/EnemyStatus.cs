using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public int hp, atk;
    public float spd;
    private PlayerStatus playerStatus;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void statusUpdate()
    {
        hp *= 2;
        if (playerStatus.lvlCount % 10 == 0)
        {
            atk *= 2;
        }
    }
}
