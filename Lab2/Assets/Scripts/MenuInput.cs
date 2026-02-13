using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuInput : MonoBehaviour
{   

    [SerializeField] private GameObject menuPanel;
    [SerializeField] private PlayerInput player;

    public bool IsGamePaused { get; private set; }


    private InputAction openMenu;

    public static MenuInput Instance { get; private set; }

    private void Awake()
    {
        // Singleton enforcement
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // optional
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        openMenu = InputSystem.actions.FindAction("UI/Menu");
        openMenu.started += ToggleMenu;


    }

    private void OnDisable()
    {
        openMenu.started -= ToggleMenu;


    }

    private void ToggleMenu(InputAction.CallbackContext context)
    {
        if (menuPanel.activeSelf) CloseMenu();

        else OpenMenu();

    }

    private void OpenMenu()
    {

        IsGamePaused = true;

        //player.GetComponent<PlayerInput>().enabled = false;
        InputSystem.actions.FindActionMap("Player").Disable();
        print("Menu will open!");

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        menuPanel.SetActive(true);
    }

    private void CloseMenu()
    {
        IsGamePaused = false;

        InputSystem.actions.FindActionMap("Player").Enable();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        menuPanel.SetActive(false);
    }


}
