using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float _targetRange = 5f;
    [SerializeField] float _turnSpeed = 7f;
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
        FaceTarget();
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
        GetComponent<Animator>().SetBool("IsAttacking", false);
        GetComponent<Animator>().SetTrigger("Move");
        navMeshAgent.SetDestination(_target.position);
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
    }

    private void FaceTarget()
    {
        Vector3 Direction = (_target.position - transform.position).normalized;
        Quaternion LookRotation = Quaternion.LookRotation(new Vector3(Direction.x, 0, Direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, LookRotation, Time.deltaTime * _turnSpeed);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _targetRange);
    }
}
