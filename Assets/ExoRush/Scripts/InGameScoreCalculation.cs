using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InGameScoreCalculation : MonoBehaviour
{
    int TotalScore;
    int EventScore;
    float PositionScore;
    public GameObject InGameUMG;
    public float PositionMultiplier = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        PositionScore = transform.position.z * PositionMultiplier;

        TotalScore = EventScore + (int) PositionScore;

        InGameUMG.GetComponent<UnityEngine.UI.Text>().text = TotalScore.ToString();
    }
}
