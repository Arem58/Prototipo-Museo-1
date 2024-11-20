using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MeteorPistol : MonoBehaviour
{
    public ParticleSystem particles;
    
    public LayerMask LayerMask;
    public Transform shootSource;
    public float distance = 10;
    
    public bool rayActivate = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x => StartShoot());
        grabInteractable.deactivated.AddListener(x => StopShoot());
        grabInteractable.selectExited.AddListener(x => StopShoot());
    }

    public void StartShoot()
    {
        particles.Play();
        rayActivate = true;
    }

    public void StopShoot()
    {
        particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        rayActivate = false;
    }

    private void Update()
    {
        if (rayActivate)
            RaycastCheck();
    }

    void RaycastCheck()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(shootSource.position, shootSource.forward, out hit, distance, LayerMask);

        if (hasHit)
        {
            hit.transform.gameObject.SendMessage("Break", SendMessageOptions.DontRequireReceiver);
        }
    }
}
