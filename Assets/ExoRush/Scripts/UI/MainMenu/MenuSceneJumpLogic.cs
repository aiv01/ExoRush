using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneJumpLogic : MonoBehaviour, IMenuInteractable
{
    [SerializeField] private string sceneName;
    public void Execute()
    {
        SceneManager.LoadScene(sceneName);
    }
}
