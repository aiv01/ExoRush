using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneJumpLogic : MonoBehaviour, IMenuInteractable
{
    [SerializeField] private string sceneName;
    [SerializeField] private bool saveOnJump = false;
    [SerializeField] private LIV liv;
    [SerializeField] private bool saveCurrency;
    [SerializeField] private bool savePowerUps;
    [SerializeField] private bool saveLeaderboard;
    [SerializeField] private bool saveScore;

    private bool jump = false;
    public void Execute()
    {
        jump = true;
    }

    private void LateUpdate()
    {
        if (jump) 
        {
            if (saveOnJump) liv.UpdateSelected(saveCurrency, savePowerUps, saveLeaderboard, saveScore);
            Time.timeScale = 1;
            LoadGame();
            
        } 
    }

    public void LoadGame()
    {
        StartCoroutine(LoadGameAsync(sceneName));
    }

    private IEnumerator LoadGameAsync(string sceneName)
    {
        /*SceneManager.LoadScene(sceneName);
        yield return null;*/
        Application.backgroundLoadingPriority = ThreadPriority.Normal;
        AsyncOperation sceneLoad = SceneManager.LoadSceneAsync(sceneName);
        sceneLoad.allowSceneActivation = false;

        while (sceneLoad.progress < 0.9f)
        {

            yield return null;
        }

        yield return null;

        sceneLoad.allowSceneActivation = true;
    }
}
