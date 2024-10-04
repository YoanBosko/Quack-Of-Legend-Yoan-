using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivationDelay : MonoBehaviour
{
    [Header("Main Settings")]
    public UnityEvent MainEvent;
    public float Delay;
    public void InvokeMainEvents()
    {
        MainEvent?.Invoke();
    }

    public void InvokeMainEventDelay()
    {
        Invoke("InvokeMainEvents", Delay);
    }

}
