using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject Player;
    public Animator BossAnimator;
    Quaternion TargetRotation;
    float YRot;

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

        TargetRotation = Quaternion.FromToRotation(transform.forward, FaceDirection);

        YRot = TargetRotation.eulerAngles.y;

        

        //YRot = YRot - transform.rotation.eulerAngles.y;       

        //if(YRot > 180)
        //{
        //    YRot = YRot - 360;
        //    YRot = YRot * -1;
        //}

        BossAnimator.SetFloat("Angle",YRot/180);

        Debug.Log(YRot);

        BossAnimator.SetTrigger("TurnTrigger");

       


    }
}
