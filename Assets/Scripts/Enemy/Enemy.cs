using System;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
    private EnemyMover _mover;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
    }

    private void FixedUpdate()
    {
        _mover.Move();
    }
}