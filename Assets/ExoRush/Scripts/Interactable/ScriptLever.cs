using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptLever : MonoBehaviour
{
    public AnimationCurve AnimationCurve;
    public float AnimSpeed = 1;
    bool Started;
    float TempTimer;
    public IslandScriptLever IslandScripLever;
    public float MaxSlideSpawn = 80;
    public AudioSource AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3 (transform.position.x + Random.Range(MaxSlideSpawn*-1,MaxSlideSpawn), transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Started == true)
        {
            TempTimer += Time.deltaTime * AnimSpeed;

            transform.rotation = Quaternion.Euler(AnimationCurve.Evaluate(TempTimer)*90, 0, 0);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!Started && other.name == "Dropship")
        {
            Started = true;
            Object.FindObjectOfType<InGameScoreCalculation>().AdditionalScore(100);
            IslandScripLever.LeverActivated();
            AudioSource.Play();
        }
    }
}
