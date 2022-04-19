using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuLogic : MonoBehaviour, IMenuInteractable
{
    public MonoBehaviour[] affectedScripts;
    public GameObject[] affectedObjs;
    public Canvas canvas;
    public GamepadMapper grid;
    private bool isActive;
    public bool IsActive
    {
        get { return isActive; }
        set
        {
            if (!isActive && value)
            {
                isActive = true;
                Cursor.visible = true;
                Pause();
            }
            else if (isActive && !value)
            {
                isActive = false;
                Cursor.visible = false;
                Resume();
            }
        }
    }

    void Awake()
    {
        isActive = false;
        Resume();
        
    }

    public void Execute()
    {
        IsActive = !IsActive;
    }

    void Pause()
    {
        Time.timeScale = 0.001f;
        AffectScriptsAndObjs();
        Cursor.visible = true;
    }

    void Resume()
    {
        Time.timeScale = 1;
        AffectScriptsAndObjs();
        Cursor.visible = false;
    }

    void AffectScriptsAndObjs()
    {
        canvas.enabled = isActive;
        grid.enabled = isActive;
        foreach (var item in affectedScripts)
        {
            item.enabled = !isActive;
        }
        foreach (var item in affectedObjs)
        {
            item.SetActive(isActive);
        }
    }


}

