using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData")]
public class PlayerData : ScriptableObject
{
    //Position and rotation
    public Vector3 defaultPosition = new Vector3(0, 0, 0);
    public Vector3 currentPosition;
    public Quaternion currentRotation;
    
    //Turn provider
    public int turn = 0;

    public void ResetPosition()
    {
        currentPosition = defaultPosition;
        currentRotation = Quaternion.identity;
    }
}
