using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera _fpCamera;
    [SerializeField] float _shootingRange = 100f;
    [SerializeField] float _damage = 10f;
    [SerializeField] ParticleSystem _muzzelFlashVFX;
    [SerializeField] GameObject _hitVFX;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        PlayMuzzelFlash();
        ProcessRaycast();
    }

    private void PlayMuzzelFlash()
    {
        _muzzelFlashVFX.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(_fpCamera.transform.position, _fpCamera.transform.forward, out hit, _shootingRange))
        {
            CreateHitImpact(hit);
            EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();
            if (enemyHealth == null) { return; }
            enemyHealth.TakeDamage(_damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit Hit)
    {
        GameObject HitImpact = Instantiate(_hitVFX, Hit.point, Quaternion.LookRotation(Hit.normal));
        Destroy(HitImpact, 0.05f);
    }
}