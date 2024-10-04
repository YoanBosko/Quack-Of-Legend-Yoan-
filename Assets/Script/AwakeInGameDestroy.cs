using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeInGameDestroy : MonoBehaviour
{
    private DestroyLoad destroyLoad;

    void Awake()
    {
        destroyLoad = FindAnyObjectByType<DestroyLoad>();
        destroyLoad.mainMenuAudio = true;
    }
}
