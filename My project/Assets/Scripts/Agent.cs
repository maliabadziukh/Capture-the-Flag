using System;
using System.Collections;
using System.Collections.Generic;
using statemachine;
using UnityEngine;
using UnityEngine.Events;

public class Agent : MonoBehaviour
{
    public float HP { get; private set; }
    public float MaxHP { get; private set; }

    public UnityEvent<float> HPEvent;
    
    private StateMachine stateMachine;
    
    private void Awake()
    {
        MaxHP = 1000;
        HP = MaxHP;
        stateMachine = new StateMachine(this);
    }
    
    void Update()
    {
        stateMachine.UpdateState();
    }

    public void UpdateHP(float amount)
    {
        HP += amount;
        HPEvent?.Invoke(HP/MaxHP);
    }
}

