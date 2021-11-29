using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameEventListener : MonoBehaviour
{
    [SerializeField] UnityEvent unityEvent;
    [SerializeField] GameEvent gameEvent;

    private void Awake()
    {
        gameEvent.Register(this);
    }

    private void OnDisable()
    {
        gameEvent.Deregister(this);
    }

    private void OnDestroy()
    {
        gameEvent.Deregister(this);
    }

    internal void RaiseEvent()
    {
        unityEvent.Invoke();
    }
}
