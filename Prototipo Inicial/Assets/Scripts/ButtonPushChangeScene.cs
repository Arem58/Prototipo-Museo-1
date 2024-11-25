using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonPushChangeScene : MonoBehaviour
{
    // Campo serializable para establecer el nombre de la escena por botón
    [SerializeField] private string sceneName;

    [SerializeField] private Material skyboxMaterial;
    void Start()
    {
        // Configura el evento del botón para llamar a la función de cambio de escena
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => ChangeScene());
    }

    public void ChangeScene()
    {
        //Guardar la posicion del jugador directamente en el ScriptableObject
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            PlayerPositionManager positionManager = player.GetComponent<PlayerPositionManager>();
            if (positionManager != null)
            {
                positionManager.SavePlayerPosition();
            }
        }
        
        // Carga la escena específica asignada al botón en el inspector
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneTransitionManager.singleton.GoToScene(sceneName, skyboxMaterial);
        }
        else
        {
            Debug.LogWarning("Scene name is not set for this button.");
        }
    }
}
