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
    public static int TransitionMapScore;
    public bool Bossmap;
    public int Roundscore;

    // Start is called before the first frame update
    void Start()
    {
        Roundscore = TransitionMapScore;
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
        if (!Bossmap)
        {
            PositionScore = transform.position.z * PositionMultiplier;
        }



        TotalScore = EventScore + (int) PositionScore + TransitionMapScore;

        InGameUMG.GetComponent<UnityEngine.UI.Text>().text = TotalScore.ToString();
    }

    public void AdditionalScore(int Score)
    {
        EventScore += Score;

        ScoreAnimation = 1;
    }

    public void TransitionMapScoreCalculator()
    {

        TotalScore = EventScore + (int)PositionScore + TransitionMapScore;

        TransitionMapScore = TotalScore;
    }
}
