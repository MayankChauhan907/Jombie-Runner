using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSys : MonoBehaviour
{

    [SerializeField] float _lightDecay = 0.1f;
    [SerializeField] float _angledecay = 1f;
    [SerializeField] float minimumAngle = 40f;
    Light _myLight;

    private void Start()
    {
        _myLight = GetComponent<Light>();
    }

    private void Update()
    {
        DecreaseLightAngle();
        DecreaselightIntensity();
    }

    private void DecreaseLightAngle()
    {
        if (_myLight.spotAngle >= minimumAngle)
        {
            _myLight.spotAngle -= _angledecay * Time.deltaTime;
        }
    }

    private void DecreaselightIntensity()
    {
        _myLight.intensity -= _lightDecay * Time.deltaTime;
    }

    public void RestoreLightAngle(float RestoreAngle)
    {
        _myLight.spotAngle = RestoreAngle;
    }

    public void AddLight(float LightIntensity)
    {
        _myLight.intensity += LightIntensity;
    }
}
