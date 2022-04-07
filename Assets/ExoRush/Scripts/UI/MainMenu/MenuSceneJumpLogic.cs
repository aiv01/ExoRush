using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSceneJumpLogic : MonoBehaviour, IMenuInteractable
{
    [SerializeField] private string sceneName;
    [SerializeField] private bool saveOnJump = false;
    [SerializeField] private LIV liv;
    [SerializeField] private bool saveCurrency;
    [SerializeField] private bool savePowerUps;
    [SerializeField] private bool saveLeaderboard;
    [SerializeField] private bool saveScore;
    public GameObject LoadingIcon;
    public Canvas UICanvas;
    public Camera MainCamera;

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
        UICanvas.enabled = false;
        LoadingIcon.SetActive(true);
    }

    private IEnumerator LoadGameAsync(string sceneName)
    {
        /*SceneManager.LoadScene(sceneName);
        yield return null;*/
        Application.backgroundLoadingPriority = ThreadPriority.Low;
        AsyncOperation sceneLoad = SceneManager.LoadSceneAsync(sceneName);

        while (sceneLoad.progress < 0.9f)
        {
            MainCamera.backgroundColor = Color.Lerp(Color.black, Color.white, sceneLoad.progress);
            yield return null;
        }

        yield return null;

    }
}
