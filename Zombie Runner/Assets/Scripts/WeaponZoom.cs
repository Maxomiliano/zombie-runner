using Cinemachine;
using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera camera;
    [SerializeField] private float defaultFOV = 40;
    [SerializeField] private float zoomedInFOV = 15;
    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = .5f;
    [SerializeField] FirstPersonController fpsController;

    bool zoomedInToggle = false;
    private void OnDisable()
    {
        ZoomOut();
    }

    public void Zoom(bool valueIsPressed)
    {

        if (zoomedInToggle == false)
        {
            ZoomIn();
        }
        else
        {
            ZoomOut();
        }
    }

    private void ZoomOut()
    {
        zoomedInToggle = false;
        camera.m_Lens.FieldOfView = defaultFOV;
        fpsController.RotationSpeed = zoomOutSensitivity;
    }

    private void ZoomIn()
    {
        zoomedInToggle = true;
        camera.m_Lens.FieldOfView = zoomedInFOV;
        fpsController.RotationSpeed = zoomInSensitivity;
    }
}
