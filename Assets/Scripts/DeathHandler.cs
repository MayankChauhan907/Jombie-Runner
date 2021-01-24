using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas _PlayerDeathCanvas;

    void Start()
    {
        _PlayerDeathCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        _PlayerDeathCanvas.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponeSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
