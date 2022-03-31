using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class TransitionAutomaticAnimation : MonoBehaviour
{
    public Volume Volume;
    bool Active;
    public float TransitionSpeed;
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Active)
        {
            Volume.weight += Time.deltaTime * TransitionSpeed;
            if(Volume.weight > 1)
            {
                Player = GameObject.FindGameObjectWithTag("Player");
                Player.GetComponent<InGameScoreCalculation>().AdditionalScore(1000);
                Player.GetComponent<InGameScoreCalculation>().TransitionMapScoreCalculator();
                SceneManager.LoadScene("DefaultMap");
            }
        }
    }

    public void Activate()
    {
        Active = true;
    }
}
