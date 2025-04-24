using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerMoveController player;

    private void Awake()
    {
        instance = this;
    }

}
