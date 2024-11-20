using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class ButtonPushChangeScene : MonoBehaviour
{
    // Campo serializable para establecer el nombre de la escena por botón
    [SerializeField] private string sceneName;

    void Start()
    {
        // Configura el evento del botón para llamar a la función de cambio de escena
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => ChangeScene());
    }

    public void ChangeScene()
    {
        // Carga la escena específica asignada al botón en el inspector
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("Scene name is not set for this button.");
        }
    }
}
