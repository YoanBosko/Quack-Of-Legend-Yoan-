using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillScript : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroyObject", 0.383f);
    }
    void Update()
    {

    }
    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
