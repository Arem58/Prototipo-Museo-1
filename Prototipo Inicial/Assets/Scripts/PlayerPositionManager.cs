using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPositionManager : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private string saveSceneName;
    [SerializeField] private string resetSceneName;
    
    // Start is called before the first frame update
    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == saveSceneName)
        {
            transform.localPosition = playerData.currentPosition;
            transform.localRotation = playerData.currentRotation;
        }
        else if (currentScene == resetSceneName)
        {
            playerData.ResetPosition();
        }
    }

    public void SavePlayerPosition()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        
        if (currentScene == saveSceneName)
        {
            playerData.currentPosition = transform.localPosition;
            playerData.currentRotation = transform.localRotation;
        }
    }
}
