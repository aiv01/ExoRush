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
	private bool isJumping = false;

	public void Execute()
	{
		jump = true;
	}

	/*
	 * [LUCA]
	 * Actually, this is bad. Checking each frame for a flag bound to an "execute" action
	 * is overkill and brings to problems (you had an example).
	 * 
	 * Do you need to wait the end of the frame in order to perform an action? Use coroutines!
	 * 
	private IEnumerator DoAtFrameEnd(System.Action task)
	{
		yield return new WaitForEndOfFrame();
		task();
	}
	 * To be called like this:
		StartCoroutine(DoAtFrameEnd(() => { ... }));
	 * or
		StartCoroutine(DoAtFrameEnd(LoadGame);
	 * 
	 * 
	 * This approach would not even need the "isJumping" flag, unless you call "Execute()" more than once,
	 * for instance if you don't disable the button.
	 */
	private void LateUpdate()
	{
		//	[LUCA]	Check if a load is in progress or this will begina  new load every frame while loading the scene the first time
		if(jump && !isJumping)
		//if(jump)	//	[LUCA] This is the former verison
		{
			if(saveOnJump) liv.UpdateSelected(saveCurrency, savePowerUps, saveLeaderboard, saveScore);
			Time.timeScale = 1;
			LoadGame();
		}
	}

	public void LoadGame()
	{
		UICanvas.enabled = false;
		LoadingIcon.SetActive(true);
		StartCoroutine(LoadGameAsync(sceneName));
	}

	private IEnumerator LoadGameAsync(string sceneName)
	{
		//	[LUCA]	Flagging the load as "in progress" you can prevent to start a new load each frame in LateUpdate
		isJumping = true;

		Application.backgroundLoadingPriority = ThreadPriority.Low;
		AsyncOperation sceneLoad = SceneManager.LoadSceneAsync(sceneName);

		while(sceneLoad.progress < 0.9f)
		{
			//	[LUCA] Progress grows up to 0.9 so the lerp will never reach white. Divinding by the cap does actually gets to 1.0
			MainCamera.backgroundColor = Color.Lerp(Color.black, Color.white, sceneLoad.progress / 0.9f);
			//	MainCamera.backgroundColor = Color.Lerp(Color.black, Color.white, sceneLoad.progress);	//	[LUCA] This is the former verison
			yield return null;
		}

		//	[LUCA]	I suggest to restore the normal thread priority once done since it affects a bunch of things other than scene load
		Application.backgroundLoadingPriority = ThreadPriority.Normal;
		yield return null;

	}
}
