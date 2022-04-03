using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossfightBeam : MonoBehaviour
{
    public GameObject BeamStartingPoint;
    Vector3 hitPos;
    float HittingTime;
    float Damage;
    public float StartingDamage = 1;
    public float ExponentialDamageAmplifier = 1;

    public GameObject BeamBar;
    public LaserBeamScript BeamEffect;

    

    //Overcharge 2
    float OverchargeEnergy = 1;
    public float OverchargeDrainedSpeed;
    public float OverchargeRegenerateSpeed;
    public float ReloadTime;
    float TempReloadTime;
    public float ReuseTime;
    float TempReuseTime;
    bool Active;

    




    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Ability")){

            if (OverchargeEnergy > 0 && TempReuseTime <= 0)
            {
                Active = true;
                OverchargeEnergy -= Time.deltaTime * OverchargeDrainedSpeed;
                TempReloadTime = ReloadTime;
            }

            if (OverchargeEnergy <= 0)
            {
                Active = false;
            }

        }
        else
        {
            Active = false;
        }

        BeamEffect.SetActivation(Active);

        if (TempReloadTime <= 0 && !Active)
        {
            OverchargeEnergy += Time.deltaTime * OverchargeRegenerateSpeed;
        }
        else
        {
            TempReloadTime -= Time.deltaTime;
        }


        if (OverchargeEnergy <= 0 && TempReuseTime <= 0)
        {
            TempReuseTime = ReuseTime;
        }
        else
        {
            TempReuseTime -= Time.deltaTime;
        }

        OverchargeEnergy = Mathf.Clamp(OverchargeEnergy, 0, 1);


        if (Active)
        {
            RaycastHit hit;
            if (Physics.Raycast(BeamStartingPoint.transform.position, BeamStartingPoint.transform.forward, out hit, Mathf.Infinity))
            {
                hitPos = hit.point;
                if (hit.collider.tag == "BossSphere")
                {
                    Damage = Mathf.Pow(StartingDamage, HittingTime);

                    Damage = Damage * Time.deltaTime * 1000;
                        
                    hit.collider.transform.root.GetComponent<EnemyMaster>().Damage((int)Damage);
                    HittingTime += Time.deltaTime * ExponentialDamageAmplifier;
                }
                else
                {
                    HittingTime = 0;
                }


            }
            else
            {
                HittingTime = 0;
            }

            Debug.DrawRay(BeamStartingPoint.transform.position, BeamStartingPoint.transform.forward * 9999, Color.green);



        }

        BeamBar.GetComponent<UnityEngine.UI.Image>().fillAmount = (float)OverchargeEnergy * -1 +1;

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(hitPos, 1);
    }
}
