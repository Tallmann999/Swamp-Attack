using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))] 
public class AttackState : State
{
   [SerializeField] private int _damage;
   [SerializeField] private float _delayTime;

    private float _lastAttackTime;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (_lastAttackTime<=0)
        {
            Attack(Target);
            _lastAttackTime = _delayTime;
        }

        _lastAttackTime -=Time.deltaTime;
    }

    private void Attack(Player target)
    {
        _animator.Play("Attack");
        target.ApplyDamage(_damage);
    }
}
