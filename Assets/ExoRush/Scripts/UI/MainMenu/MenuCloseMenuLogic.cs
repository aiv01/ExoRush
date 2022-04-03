using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCloseMenuLogic : MonoBehaviour, IMenuInteractable
{
    private PauseMenuLogic pauseMenu;
    public Canvas canvas;
    private bool isActive = false;

    void Awake()
    {
        pauseMenu = GetComponent<PauseMenuLogic>();
        canvas.enabled = isActive;
    }

    public void Execute()
    {
        isActive = !isActive;
        canvas.enabled = isActive;
        pauseMenu.IsActive = !isActive;
    }
}
