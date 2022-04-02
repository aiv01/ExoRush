using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject Player;
    public Animator BossAnimator;
    public BoxCollider MeleeHitBox;
    public BoxCollider RangeHitBox;

    Collider[] BoxResults;

    AnimatorClipInfo[] CurrentClipName;

    public AudioSource TurnAudio;

    //Rotation
    public float RotationTollerance;
    public float RotationTimer;
    float RotationTempTimer;

    //MeleeAttack
    public float MeleeTimer;
    float MeleeTempTimer;
    public AudioSource MeleeAttackSource;

    //RangeAttack
    public float RangeTimer;
    float RangeTempTimer;
    public AudioSource RangeAttackSource;


    // Start is called before the first frame update
    void Start()
    {
        RangeTempTimer = RangeTimer;
        MeleeTempTimer = MeleeTimer;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentClipName = BossAnimator.GetCurrentAnimatorClipInfo(0);

        if (BossAnimator.GetCurrentAnimatorStateInfo(0).IsName("Turn"))
        {
            TurnAudio.volume = 1;
        }
        else
        {
            TurnAudio.volume = 0;
        }

        if (CurrentClipName[0].clip.name == "Grenadier_MeleeAttack")
        {
            //Debug.Log(CurrentClipName[0].clip.AddEvent());
        }

        RotationTempTimer = RotationTempTimer - Time.deltaTime;

        if (RotationTempTimer < 0)
        {
            RotateToPlayer();
            RotationTempTimer = RotationTimer;
        }

        MeleeTempTimer = MeleeTempTimer - Time.deltaTime;

        if (MeleeTempTimer < 0)
        {
            MaleeAttack();
            MeleeTempTimer = MeleeTimer;
        }

        RangeTempTimer = RangeTempTimer - Time.deltaTime;

        if (RangeTempTimer < 0)
        {
            RangeAttack();
            RangeTempTimer = RangeTimer;
        }

    }

    void RotateToPlayer()
    {
        Vector3 FaceDirection = Player.transform.position - transform.position;

        Vector3 From = transform.forward;

        From.y = 0;

        FaceDirection.y = 0;


        float Angle = Vector3.SignedAngle(From, FaceDirection, Vector3.up);

        if ((Angle > 0 && Angle > RotationTollerance) || (Angle < 0 && Angle < RotationTollerance * -1))
        {
            BossAnimator.SetFloat("Angle", Angle / 180);

            BossAnimator.SetTrigger("TurnTrigger");
        }

    }



    void MaleeAttack()
    {
        BossAnimator.SetTrigger("MeleeAttack");
        
    }

    void RangeAttack()
    {
        BossAnimator.SetTrigger("RangeAttack");
       
    }

    public void StartAttack()
    {
        MeleeAttackSource.Play();
        BoxResults = (Physics.OverlapBox(MeleeHitBox.transform.TransformPoint(MeleeHitBox.center),MeleeHitBox.size/2*MeleeHitBox.transform.lossyScale.x,MeleeHitBox.transform.rotation));
        for (int i = 0; i < BoxResults.Length; i++)
        {
            if(BoxResults[i].transform.name == "RushDropship")
            {
                BoxResults[i].GetComponent<InGameHealth>().Damage(700, false, false, false);
            }           
            
        }
            
    }

    public void Shoot()
    {
        RangeAttackSource.Play();
        BoxResults = (Physics.OverlapBox(RangeHitBox.transform.TransformPoint(RangeHitBox.center), RangeHitBox.size / 2 * RangeHitBox.transform.lossyScale.x, RangeHitBox.transform.rotation));
        for (int i = 0; i < BoxResults.Length; i++)
        {
            if (BoxResults[i].transform.name == "RushDropship")
            {

               BoxResults[i].GetComponent<InGameHealth>().Damage(500, false, false, false);
                
            }

        }
    }



    public void EndAttack()
    {

    }

    public void PlayStep()
    {

    }


}

