using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerTurnTypeManager : MonoBehaviour
{

    [SerializeField] private PlayerData playerData;
    [SerializeField] private ActionBasedSnapTurnProvider snapTurn;
    [SerializeField] private ActionBasedContinuousTurnProvider continuousTurn;
    
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
            snapTurn.rightHandSnapTurnAction.action.Enable();
            continuousTurn.rightHandTurnAction.action.Disable();
        }
        else if (value == 1)
        {
            snapTurn.rightHandSnapTurnAction.action.Disable();
            continuousTurn.rightHandTurnAction.action.Enable();
        }
    }
}
