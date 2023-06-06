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

    public void Zoom(bool valueIsPressed)
    {
        if (zoomedInToggle == false)
        {
            zoomedInToggle = true;
            camera.m_Lens.FieldOfView = zoomedInFOV;
            fpsController.RotationSpeed = zoomInSensitivity;
        }
        else
        {
            zoomedInToggle = false;
            camera.m_Lens.FieldOfView = defaultFOV;
            fpsController.RotationSpeed = zoomOutSensitivity;
        }





    /*
    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomedInFOV = 60f;
    [SerializeField] float zoomedOutFOV = 40f;
    */

    /*
    public void Zoom(bool zoomedIn)
    {
        camera.m_Lens.FieldOfView = zoomedIn ? zoomedInFOV : defaultFOV;
    }
    */

    /*
    public void Zoom(bool valueIsPressed)
    {
        Mouse mouse = InputSystem.GetDevice<Mouse>();
        if (mouse.rightButton.wasPressedThisFrame)
        {
            if (zoomedInToggle == false)
            {
                zoomedInToggle = true;
                fpsCamera.fieldOfView = zoomedInFOV;
            }
            else
            {
                zoomedInToggle = false;
                fpsCamera.fieldOfView = zoomedOutFOV;
            }
        }
    }
    */
    }
}
