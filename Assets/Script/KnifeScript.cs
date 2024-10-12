using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript : MonoBehaviour
{
    public Animator animation;
    GameObject playerObject;

    float spd = 100f;

    void Start()
    {
    }
    void Update()
    {
        playerObject = GameObject.Find("Player");
        transform.position = Vector3.MoveTowards(transform.position, playerObject.transform.position, spd * Time.deltaTime);
    }
}
