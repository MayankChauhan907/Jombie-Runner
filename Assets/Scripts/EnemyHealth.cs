using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float _hitPoints = 100f;
    bool _isDead = false;

    public void TakeDamage(float Damage)
    {
        if (_isDead) return;

        BroadcastMessage("OnDamageTaken");
        _hitPoints -= Damage;
        if (_hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _isDead = true;
        GetComponent<Animator>().SetTrigger("Die");
        GetComponent<EnemyAI>().enabled = false;
    }
}
