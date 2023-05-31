using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour //IPointerClickHandler
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;

    void Update()
    {
        /*
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        */
        Mouse ms = InputSystem.GetDevice<Mouse>();

        if (ms.leftButton.wasPressedThisFrame) 
        {
            Shoot();        
        }

    }


    private void Shoot()
    {
        if (ammoSlot.GetCurrentAmmo() > 0)
        {
        PlayMuzzleFlash();
        ProcessRaycast();
        ammoSlot.ReduceCurrentAmmo();
        }
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {

            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            // call a method on EnemyHealth that decreases the enemy's health
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }

    /*
    public void OnPointerClick(PointerEventData eventData)
    {
        Shoot();
    }
    */
}
