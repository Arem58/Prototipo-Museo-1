using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class DisableGrabbingHandModel : MonoBehaviour
{
    public GameObject leftHandModel;
    public GameObject rightHandModel;

    private void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(HideGrabbingHand);
        grabInteractable.selectExited.AddListener(ShowGrabbingHand);
    }

    public void HideGrabbingHand(SelectEnterEventArgs args)
    {
        Transform parentObject = args.interactorObject.transform.parent;

        if (parentObject.tag == "Left Hand")
        {
            leftHandModel.SetActive(false);
        }
        else if (parentObject.tag == "Right Hand")
        {
            rightHandModel.SetActive(false);
        }     
    }

    public void ShowGrabbingHand(SelectExitEventArgs args)
    {
        Transform parentObject = args.interactorObject.transform.parent;

        if (parentObject.tag == "Left Hand")
        {
            leftHandModel.SetActive(true);
        }
        else if (parentObject.tag == "Right Hand")
        {
            rightHandModel.SetActive(true);
        }

    }
}
