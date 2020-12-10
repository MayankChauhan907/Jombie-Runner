using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float _hitPoints = 100f;

    public void TaleDamage(float Damage)
    {
        _hitPoints -= Damage;
        if (_hitPoints <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
