using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera _fpCamera;
    [SerializeField] float _zoomOutFpc = 60f;
    [SerializeField] float _zoomInFpc = 30f;
    [SerializeField] float _zoomOutSensitivity = 2f;
    [SerializeField] float _zoomInSensitivity = 0.5f;
    bool _zoomToggle = false;
    RigidbodyFirstPersonController _fpController;

    private void Start()
    {
        _fpController = GetComponentInParent<RigidbodyFirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (_zoomToggle == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    private void ZoomIn()
    {
        _zoomToggle = true;
        _fpCamera.fieldOfView = _zoomInFpc;
        _fpController.mouseLook.XSensitivity = _zoomInSensitivity;
        _fpController.mouseLook.YSensitivity = _zoomInSensitivity;
    }

    private void ZoomOut()
    {
        _zoomToggle = false;
        _fpCamera.fieldOfView = _zoomOutFpc;
        _fpController.mouseLook.XSensitivity = _zoomOutSensitivity;
        _fpController.mouseLook.YSensitivity = _zoomOutSensitivity;
    }

    void OnDisable()
    {
        ZoomOut();
    }
}
