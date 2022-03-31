using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAudioEffect : MonoBehaviour
{
    public AudioSource AudioSource;
    public float StartingFadeDuration = 1;
    float FadeINTimer = 1;
    float TotalFadeINDuration = 1;
    float FadeINAudioValue = 1;
    float FadeOUTTimer = 1;
    float TotalFadeOUTDuration = 1;
    float FadeOUTAudioValue = 1;


    //FadeIn


    void Start()
    {
        FadeIN(StartingFadeDuration);
    }
    void Update()
    {
        if(FadeOUTTimer > 0)
        {
            FadeOUTTimer -= Time.deltaTime;
            FadeOUTAudioValue = Mathf.Clamp((FadeOUTTimer / TotalFadeOUTDuration), 0, 1);
            AudioSource.volume = FadeOUTAudioValue;
        }
        if(FadeINTimer > 0)
        {
            FadeINTimer -= Time.deltaTime;
            FadeINAudioValue = Mathf.Clamp((((FadeINTimer / TotalFadeINDuration) * -1) + 1), 0, 1);
            AudioSource.volume = FadeINAudioValue;
        }



    }
    public void FadeIN(float Duration)
    {
        TotalFadeINDuration = Duration;
        FadeINTimer = Duration;
    }

    public void FadeOUT(float Duration)
    {
        TotalFadeOUTDuration = Duration;
        FadeOUTTimer = Duration;
    }
}
