using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtunPush : MonoBehaviour
{
    public GameObject glass;

    private bool open = false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => ToggleGlassOpen());
    }

    public void ToggleGlassOpen()
    {
        open = !open;
        glass.SetActive(open);
    }
}
