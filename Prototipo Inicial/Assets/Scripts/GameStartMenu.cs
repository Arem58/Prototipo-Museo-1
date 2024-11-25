using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartMenu : MonoBehaviour
{
    [Header("UI Pages")] 
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject about;
    
    [Header("Hand Menu Buttons")] 
    [SerializeField] private Button startButton;
    [SerializeField] private Button optionButton;
    [SerializeField] private Button aboutButton;
    [SerializeField] private Button quitButton;

    public List<Button> returnButton;

    [Header("Parameters scene")] 
    [SerializeField] private string sceneName;
    [SerializeField] private Material skyboxMaterial;
    
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(startGame);
        optionButton.onClick.AddListener(EnableOption);
        aboutButton.onClick.AddListener(EnableAbout);
        quitButton.onClick.AddListener(QuitGame);

        foreach (var item in returnButton)
        {
            item.onClick.AddListener(EnableMainMenu);
        }
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void startGame()
    {
        HideAll();
        SceneTransitionManager.singleton.GoToScene(sceneName, skyboxMaterial);
    }
    
    public void HideAll()
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
        about.SetActive(false);
    }
    
    public void EnableMainMenu()
    {
        mainMenu.SetActive(true);
        options.SetActive(false);
        about.SetActive(false);
    }

    public void EnableOption()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
        about.SetActive(false);
    }
    public void EnableAbout()
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
        about.SetActive(true);
    }
}
