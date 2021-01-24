using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float _lightAngle, _lightIntensity;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<FlashLightSys>().RestoreLightAngle(_lightAngle);
            other.GetComponentInChildren<FlashLightSys>().AddLight(_lightIntensity);
            Destroy(this.gameObject);
        }
    }
}
