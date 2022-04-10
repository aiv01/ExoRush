using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndMenuAnimation : MonoBehaviour
{
    public RectTransform RectTransform;
    public float OpenSpeed = 1;
    float CurrentSize;
    public AnimationCurve OpenCurve;
    float AnimValue;
    public float WaitTime;
    public Vector3 EndValue;
    public bool OnlyXValue;

    // Start is called before the first frame update
    void Start()
    {
        RectTransform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (WaitTime > 0)
        {
            WaitTime -= Time.deltaTime;
        }
        else
        {
            CurrentSize += Time.deltaTime * OpenSpeed;
            CurrentSize = Mathf.Clamp01(CurrentSize);
            AnimValue = OpenCurve.Evaluate(CurrentSize);
            if (!OnlyXValue)
            {
                RectTransform.localScale = new Vector3(EndValue.x * AnimValue, EndValue.y * AnimValue, EndValue.z * AnimValue);
            }
            else
            {
                RectTransform.localScale = new Vector3(EndValue.x * AnimValue, EndValue.y, EndValue.z);
            }
            
            //gameObject.transform.localScale = new Vector3 (CurrentSize, CurrentSize, CurrentSize);
        }


    }
}
