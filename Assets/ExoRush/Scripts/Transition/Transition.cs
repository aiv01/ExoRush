using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<InGameScoreCalculation>().TransitionMapScoreCalculator();
            SceneManager.LoadScene("BossMap");
            Debug.Log("OpenMap");

        }
    }

}
