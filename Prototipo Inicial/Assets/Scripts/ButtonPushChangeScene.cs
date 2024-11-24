using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

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
        // Carga la escena específica asignada al botón en el inspector
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            
            //Cambiar de escena
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("Scene name is not set for this button.");
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (skyboxMaterial != null)
        {
            RenderSettings.skybox = skyboxMaterial;
            
        }
        else
        {
            Material defaultSkybox = Resources.Load<Material>("Default-Skybox");
            if (defaultSkybox != null)
            {
                RenderSettings.skybox = defaultSkybox;
            }
            else
            {
                Debug.LogWarning("Default Skybox not found. Make sure it's available in Resources.");
            }
        }
        
        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Skybox;
        DynamicGI.UpdateEnvironment();
        
        // Desuscribirse del evento para evitar problemas
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
