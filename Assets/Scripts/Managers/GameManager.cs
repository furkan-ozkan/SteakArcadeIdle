using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            playerCommandInvoker = new PlayerCommandInvoker();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    #region Variables

    public PlayerStateManager playerStateManager;
    public FloatingJoystick joystick;
    public GameObject character;
    public PlayerData playerData;
    public Animator animator;
    public Inventory inventory;
    public GameObject walkVFX;
    public GameObject collectablePlace;
    public GameObject collectablePlaceParent;
    public PlayerCommandInvoker playerCommandInvoker { get; private set; }

    #endregion

}
