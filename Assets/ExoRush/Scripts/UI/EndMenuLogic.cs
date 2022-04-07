using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenuLogic : MonoBehaviour
{
    private float endMenuTimer;
    private GameObject EndMenu;
    private GameObject PauseMenu;

    private bool start = false;
    private float counter = 0;

    public EndMenuLogic(GameObject _endMenu, GameObject _pauseMenu, float timer)
    {
        EndMenu = _endMenu;
        PauseMenu = _pauseMenu;
        endMenuTimer = timer;
    }

    public void Initialise(GameObject _endMenu, GameObject _pauseMenu, float timer)
    {
        EndMenu = _endMenu;
        PauseMenu = _pauseMenu;
        endMenuTimer = timer;
    }

    public void StartCounter()
    {
        start = true;
    }

    private void Awake()
    {
        counter = 0;
        start = false;
    }

    private void Update()
    {
        if (start)
        {
            counter += Time.deltaTime;
            if (counter >= endMenuTimer)
            {
                EndMenu.SetActive(true);
                PauseMenu.SetActive(false);
                
                start = false;
            }
        }
    }
}
