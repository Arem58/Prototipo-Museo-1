using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ReturnObjectonCollision : MonoBehaviour
{

    public Transform targetTransform; // Transform al que se teletransportará el objeto
    public string targetTagGround; // Tag para el suelo
    public string targetTagWall; // Tag para la pared
    
    private bool isGrabbed = false; // Estado del objeto (si está siendo agarrado)
    
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(setIsGrabbedEntered);
            grabInteractable.selectExited.AddListener(setIsGrabbedExited);
        }
    }

    public void setIsGrabbedEntered(SelectEnterEventArgs args)
    {
        isGrabbed = true;
    }

    public void setIsGrabbedExited(SelectExitEventArgs args)
    {
        isGrabbed = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        // Verifica si el objeto no está agarrado y colisiona con el suelo o la pared
        if (!isGrabbed && (other.gameObject.CompareTag(targetTagWall) || other.gameObject.CompareTag(targetTagGround)))
        {
            gameObject.transform.position = targetTransform .position;
            gameObject.transform.rotation = targetTransform .rotation;
        }
    }
}
