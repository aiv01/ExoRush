using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptLever : MonoBehaviour
{
    public AnimationCurve AnimationCurve;
    public float AnimSpeed = 1;
    bool Started;
    float TempTimer;

    // Start is called before the first frame update
    void Start()
    {
        
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

        }
    }
}
