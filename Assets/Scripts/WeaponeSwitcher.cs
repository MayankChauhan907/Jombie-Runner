using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponeSwitcher : MonoBehaviour
{
    [SerializeField] int _currentIndex = 0;
    void Start()
    {
        SwitchWeapon();
    }

    void Update()
    {
        int PreviuseWeapon = _currentIndex;

        ProcessKeyInput();
        ProcessScrollWheel();

        if (PreviuseWeapon != _currentIndex)
        {
            SwitchWeapon();
        }

    }

    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _currentIndex = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _currentIndex = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _currentIndex = 2;
        }
    }

    private void ProcessScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (_currentIndex >= transform.childCount - 1)
            {
                _currentIndex = 0;
            }
            else
            {
                _currentIndex++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (_currentIndex <= 0)
            {
                _currentIndex = transform.childCount - 1;
            }
            else
            {
                _currentIndex--;
            }
        }
    }

    private void SwitchWeapon()
    {
        int WeaponIndex = 0;
        foreach (Transform weapon in transform)
        {
            if (WeaponIndex == _currentIndex)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            WeaponIndex++;
        }
    }
}
