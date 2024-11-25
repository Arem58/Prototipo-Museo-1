using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public FadeScreen fadeScreen;
    public static SceneTransitionManager singleton;

    private Material skyboxMaterial;

    private void Awake()
    {
        if (singleton && singleton != this) Destroy(singleton);

        singleton = this;
    }

    public void GoToScene(string sceneName, Material skyboxMaterial)
    {
        this.skyboxMaterial = skyboxMaterial;
        
        StartCoroutine(GoToSceneRoutine(sceneName, skyboxMaterial));
    }

    IEnumerator GoToSceneRoutine(string sceneName, Material skyboxMaterial)
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);
        
        SceneManager.sceneLoaded += OnSceneLoaded;
        
        //Launch the new scene
        SceneManager.LoadScene(sceneName);
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
