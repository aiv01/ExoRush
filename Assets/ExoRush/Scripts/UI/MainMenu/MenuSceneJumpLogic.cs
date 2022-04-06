using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuSceneJumpLogic : MonoBehaviour, IMenuInteractable
{
    [SerializeField] private string sceneName;
    [SerializeField] private bool saveOnJump = false;
    [SerializeField] private LIV liv;
    [SerializeField] private bool saveCurrency;
    [SerializeField] private bool savePowerUps;
    [SerializeField] private bool saveLeaderboard;
    [SerializeField] private bool saveScore;

    private TMP_Text text;
    private bool jump = false;

    void Awake()
    {
        text = GetComponentInChildren<TMP_Text>();
    }

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
            text.text = "LOADING...";
            SceneManager.LoadScene(sceneName);
        } 
    }
}
