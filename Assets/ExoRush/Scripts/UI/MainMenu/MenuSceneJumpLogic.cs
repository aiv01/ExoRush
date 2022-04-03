using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneJumpLogic : MonoBehaviour, IMenuInteractable
{
    [SerializeField] private string sceneName;
    [SerializeField] private bool saveOnJump = false;
    [SerializeField] private LoadItemsValues liv;

    private bool jump = false;
    public void Execute()
    {
        jump = true;
    }

    private void LateUpdate()
    {
        if (jump) 
        {
            if (saveOnJump) liv.UpdateSelected(true, true);
            Time.timeScale = 1;
            SceneManager.LoadScene(sceneName);
        } 
    }
}
