using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FusionCannonEffectManager : MonoBehaviour
{
    bool IsMoving;
    Vector3 EndPosition;
    public TrailRenderer TrailRenderer;
    public float TrailTime = 0.1f;
    float TempTrailSteel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TempTrailSteel < 0)
        {
            this.gameObject.SetActive(false);
        }

        if (IsMoving)
        {
            transform.position = EndPosition;
            IsMoving = false;
        }


    }

    public void Started(Vector3 StartPos,Vector3 EndPos)
    {
        transform.position = StartPos;
        EndPosition = EndPos;
        IsMoving = true;
        TrailRenderer.Clear();
        TempTrailSteel = TrailTime;

    }
}
