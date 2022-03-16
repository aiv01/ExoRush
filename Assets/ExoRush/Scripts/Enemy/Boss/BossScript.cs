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

        TargetRotation = Quaternion.LookRotation(FaceDirection);

        YRot = TargetRotation.eulerAngles.y;

        YRot = YRot - transform.rotation.eulerAngles.y;

        Debug.Log(YRot);

        BossAnimator.SetFloat("Angle",YRot/180);

        BossAnimator.SetTrigger("TurnTrigger");
        

    }
}
