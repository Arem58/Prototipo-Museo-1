using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionHandMenu : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Dropdown turnDropdown;
    [SerializeField] private PlayerTurnTypeManager playerTurnTypeManager;
    
    // Start is called before the first frame update
    void Start()
    {
        // Inicializa el valor del dropdown segun el estado guardado
        turnDropdown.value = playerTurnTypeManager.playerData.turn;
        
        turnDropdown.onValueChanged.AddListener(SetTurnPlayerPref);
    }

    public void SetTurnPlayerPref(int value)
    {
        //Actualiza el valor en el ScriptableObject
        playerTurnTypeManager.playerData.turn = value;
        
        playerTurnTypeManager.ApplyPlayerPref();
    }
}
