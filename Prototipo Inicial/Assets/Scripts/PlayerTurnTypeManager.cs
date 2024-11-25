using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class PlayerTurnTypeManager : MonoBehaviour
{

    public PlayerData playerData;
    [SerializeField] private ActionBasedControllerManager controllerManager;
    
    // Start is called before the first frame update
    void Start()
    {
        ApplyPlayerPref();
    }

    public void ApplyPlayerPref()
    {
        int value = playerData.turn;

        if (value == 0)
        {
            EnableSnapTurn();
        }
        else
        {
            EnableContinuousTurn();
        }
    }

    private void EnableSnapTurn()
    {
        controllerManager.smoothTurnEnabled = false;
    }
    
    private void EnableContinuousTurn()
    {
        controllerManager.smoothTurnEnabled = true;
    }
}
