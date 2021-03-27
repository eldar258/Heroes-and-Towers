using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public Transform CenterHand;

    private IState curState;
    private Dictionary<Type, IState> behaviors = new Dictionary<Type, IState>();


    void Start()
    {
        Animator animator = GetComponent<Animator>();
        behaviors[typeof(StateMovement)] = new StateMovement(animator, 
            GetComponent<NavMeshAgent>());
        behaviors[typeof(StateShoot)] = new StateShoot(animator, CenterHand);

        SetState<StateMovement>();
    }

    void Update()
    {
        curState.GraphicAction();
    }

    private void FixedUpdate()
    {
        curState.PhysicAction();
    }

    public void SetState<T>() where T : IState
    {
        IState newState = GetState<T>();
        if (curState != null) curState.Exit();
        curState = newState;
        curState.Enter();
    }

    public IState GetState<T>() where T : IState
    {
        return behaviors[typeof(T)];
    }
}
