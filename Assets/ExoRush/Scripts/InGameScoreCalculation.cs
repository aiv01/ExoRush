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
    public AnimationCurve AdditionalScoreAnimation;
    float ScoreAnimation;
    public float AnimationSizeMultiplier;
    public float AnimationSpeed = 5;
    public GameObject AdditonalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if(ScoreAnimation > 0)
        {

            InGameUMG.GetComponent<UnityEngine.UI.Text>().fontSize = ((int)(AdditionalScoreAnimation.Evaluate(ScoreAnimation)* AnimationSizeMultiplier) + 79);
            ScoreAnimation -= Time.deltaTime*AnimationSpeed;


        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        PositionScore = transform.position.z * PositionMultiplier;

        TotalScore = EventScore + (int) PositionScore;

        InGameUMG.GetComponent<UnityEngine.UI.Text>().text = TotalScore.ToString();
    }

    public void AdditionalScore(int Score)
    {
        EventScore += Score;

        ScoreAnimation = 1;
    }
}
