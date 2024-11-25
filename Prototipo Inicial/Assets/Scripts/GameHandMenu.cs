using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandMenu : MonoBehaviour
{
    [Header("UI Pages")] 
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject options;

    [Header("Hand Menu Buttons")] 
    [SerializeField] private Button teleportA;
    [SerializeField] private Button teleportB;
    [SerializeField] private Button teleportC;
    
    [Header(("Options Buttons"))]
    [SerializeField] private Button homeButton;
    [SerializeField] private Button optionButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button returnButton;

    [Header("Positions")] 
    [SerializeField] private GameObject positionA;
    [SerializeField] private GameObject positionB;
    [SerializeField] private GameObject positionC;
    
    // Start is called before the first frame update
    void Start()
    {
        EnableMainMenu();
        
        //Hooks events
        teleportA.onClick.AddListener(TeleportA);
        teleportB.onClick.AddListener(TeleportB);
        teleportC.onClick.AddListener(TeleportC);
        
        homeButton.onClick.AddListener(ReturnMainMenu);
        optionButton.onClick.AddListener(EnableOption);
        quitButton.onClick.AddListener(QuitGame);
        returnButton.onClick.AddListener(EnableMainMenu);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnMainMenu()
    {
        HideAll();
    }

    public void TeleportA()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = positionA.transform.position;
    }
    
    public void TeleportB()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = positionB.transform.position;
    }
    
    public void TeleportC()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = positionC.transform.position;
    }

    public void HideAll()
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
    }

    public void EnableMainMenu()
    {
        mainMenu.SetActive(true);
        options.SetActive(false);
    }

    public void EnableOption()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
    }
}
