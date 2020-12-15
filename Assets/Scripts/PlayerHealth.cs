using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float _playerHealth = 100f;

    public void TakeDamage(float Damage)
    {
        _playerHealth -= Damage;
        if (_playerHealth <= 0)
        {
            Debug.Log("Death");
        }
    }
}
