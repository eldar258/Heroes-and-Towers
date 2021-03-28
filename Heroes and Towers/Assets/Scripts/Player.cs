using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
/// <summary>
/// Описывает логику игрока
/// </summary>
public class Player : MonoBehaviour
{
    /// <summary>
    /// Расположение центра руки
    /// </summary>
    public Transform CenterHand;

    private IState curState;
    private Dictionary<Type, IState> behaviors = new Dictionary<Type, IState>();


    void Start()
    {
        Animator animator = GetComponent<Animator>();
        behaviors[typeof(StateMovement)] = new StateMovement();
        behaviors[typeof(StateShoot)] = new StateShoot();

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
    /// <summary>
    /// Смена состояния
    /// </summary>
    /// <typeparam name="T">Тип состояния, на которое нужно поменять</typeparam>
    public void SetState<T>() where T : IState
    {
        IState newState = GetState<T>();
        if (curState != null) curState.Exit();
        curState = newState;
        curState.Enter();
    }
    /// <summary>
    /// Получение из типа состояния объект состояния
    /// </summary>
    /// <typeparam name="T">Тип состояния, которое нужно получить</typeparam>
    /// <returns>Объект состояния соответсвующего типа</returns>
    public IState GetState<T>() where T : IState
    {
        return behaviors[typeof(T)];
    }
}
