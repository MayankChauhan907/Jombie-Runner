using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float _targetRange = 5f;
    [SerializeField] bool _isProvoked = false;
    float _distanceToTarget = Mathf.Infinity;
    NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        _distanceToTarget = Vector3.Distance(_target.position, transform.position);
        if (_isProvoked)
        {
            EngageTarget();
        }
        else if (_distanceToTarget <= _targetRange)
        {
            _isProvoked = true;
        }
    }

    private void EngageTarget()
    {
        if (_distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            chaseTarget();
        }
        if (_distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void chaseTarget()
    {
        navMeshAgent.SetDestination(_target.position);
    }

    private void AttackTarget()
    {
        throw new NotImplementedException();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _targetRange);
    }
}
