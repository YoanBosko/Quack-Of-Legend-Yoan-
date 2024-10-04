using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeMainMenuDestroy : MonoBehaviour
{
    private DestroyLoad destroyLoad;

    void Awake()
    {
        destroyLoad = FindAnyObjectByType<DestroyLoad>();
        destroyLoad.settingsAudio = true;
        destroyLoad.startAudio = true;
    }
}