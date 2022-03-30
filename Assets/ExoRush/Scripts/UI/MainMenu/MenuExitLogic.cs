using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuExitLogic : MonoBehaviour, IMenuInteractable
{
    public void Execute()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
