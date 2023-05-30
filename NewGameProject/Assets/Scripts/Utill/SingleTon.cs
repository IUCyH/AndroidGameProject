using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTon<T> : MonoBehaviour where T : SingleTon<T>
{
    public static T Instance { get; private set; }

    protected virtual void OnAwake(){}
    protected virtual void OnStart(){}

    void Awake()
    {
        if (Instance == null)
        {
            Instance = (T)this;
            OnAwake();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (Instance != null)
        {
            OnStart();
        }
    }
}
