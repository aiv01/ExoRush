using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject Player;
    public Animator BossAnimator;
    public float RotationTollerance;
    public float RotationTimer;
    float RotationTempTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        RotateToPlayer();
    }
    
    void RotateToPlayer()
    {
        Vector3 FaceDirection = Player.transform.position - transform.position;

        Vector3 From = transform.forward;

        From.y = 0;


        FaceDirection.y = 0;


        float Angle = Vector3.SignedAngle(From, FaceDirection,Vector3.up);

        if((Angle > 0 && Angle > RotationTollerance)|| (Angle < 0 && Angle < RotationTollerance*-1))
        {
            BossAnimator.SetFloat("Angle", Angle / 180);

            Debug.Log(Angle);

            BossAnimator.SetTrigger("TurnTrigger");
        }



       


    }
}
