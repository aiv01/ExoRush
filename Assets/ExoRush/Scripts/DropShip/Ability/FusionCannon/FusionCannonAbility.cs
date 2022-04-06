using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FusionCannonAbility : MonoBehaviour
{
    public GameObject[] FusionCannon;
    public int AmountOfBulletsForEachCannon = 100;
    bool RightCannon;
    GameObject[] HitPool;
    public GameObject HitEffect;
    public float ReloadTime = 0.1f;
    float ReloadTimer;
    public float ProjectileSpread = 0.1f;
    Vector3 SpreadedProjectileDirection;
    public GameObject TrailEffect;
    GameObject[] TrailPool;
    Vector3 OutWithRandomness;
    public float AdditionalRandomness = 5;
    public float DamageDistance = 10;
    public int Damage;
    public bool CanActivate;
    public AudioSource[] Audio;

    //LVL
    public LIVDefMap AbilityLoader;
    public int AbilityLvl;
    public int AbilityIndex;

    public LayerMask Layer;

    // Start is called before the first frame update
    void Start()
    {
        AbilityLvlLoader();

        HitPool = new GameObject[AmountOfBulletsForEachCannon + 1];

        TrailPool = new GameObject[AmountOfBulletsForEachCannon + 1];

        for (int i = 0; i < AmountOfBulletsForEachCannon; i++)
        { 
            HitPool[i] = Instantiate(HitEffect, new Vector3(-100000,0,0),Quaternion.Euler(0,0,0));

            TrailPool[i] = Instantiate(TrailEffect, new Vector3(-100000, 0, 0), Quaternion.Euler(0, 0, 0));
        }
    }

    void Update()
    {        
        ReloadTimer = ReloadTimer - Time.deltaTime;
    }


    void LateUpdate()
    {
        RaycastHit hit;


        if (CanActivate)
        {

            SetAudioVolume(1);

            if(ReloadTimer <= 0)
            {
                RightCannon = !RightCannon;

                for (int i = 0; i < AmountOfBulletsForEachCannon; i++)
                {
                    if (RightCannon)
                    {
                        //SpreadedProjectileDirection = Vector3.Lerp(FusionCannon[0].transform.forward, FusionCannon[0].transform.right*-1,Random.Range(0,ProjectileSpread));
                        //SpreadedProjectileDirection = Vector3.Lerp(SpreadedProjectileDirection, FusionCannon[0].transform.up, Random.Range(0, ProjectileSpread));

                        if (!Physics.Raycast(FusionCannon[0].transform.position, FusionCannon[0].transform.forward + new Vector3(Random.Range(AdditionalRandomness*-1, AdditionalRandomness), Random.Range(AdditionalRandomness * -1, AdditionalRandomness), Random.Range(AdditionalRandomness * -1, AdditionalRandomness)), out hit, DamageDistance, Layer))
                        {
                            continue;
                        }
                        Debug.DrawLine(FusionCannon[0].transform.position, OutWithRandomness, Color.green);
                        

                        TrailPool[i].GetComponent<FusionCannonEffectManager>().Started(FusionCannon[0].transform.position, hit.point);


                    }
                    else
                    {
                        //SpreadedProjectileDirection = Vector3.Lerp(FusionCannon[1].transform.forward, FusionCannon[1].transform.right, Random.Range(0, ProjectileSpread));
                        //SpreadedProjectileDirection = Vector3.Lerp(SpreadedProjectileDirection, FusionCannon[1].transform.up, Random.Range(0, ProjectileSpread));

                        if (!Physics.Raycast(FusionCannon[1].transform.position, FusionCannon[0].transform.forward + new Vector3(Random.Range(AdditionalRandomness * -1, AdditionalRandomness), Random.Range(AdditionalRandomness * -1, AdditionalRandomness), Random.Range(AdditionalRandomness * -1, AdditionalRandomness)), out hit, DamageDistance, Layer))
                        {
                            continue;
                        }
                        Debug.DrawLine(FusionCannon[1].transform.position, hit.point, Color.green);

                        TrailPool[i].GetComponent<FusionCannonEffectManager>().Started(FusionCannon[1].transform.position, hit.point);
                    }


                    TrailPool[i].SetActive(true);

                    HitPool[i].transform.position = hit.point;
                    HitPool[i].GetComponent<ParticleSystem>().time = 0;

                    if (hit.collider.gameObject.GetComponent<EnemyMaster>() != null)
                    {
                        hit.collider.gameObject.GetComponent<EnemyMaster>().Damage(Damage);

                    }

                    
                }
                ReloadTimer = ReloadTime;
            }



        }
        else
        {
            SetAudioVolume(0);
        }

    }

    public void SetAudioVolume(float Volume)
    {
        for (int i = 0; i < Audio.Length; i++)
        {
            Audio[i].volume = Volume;
        }
    }

    public void AbilityLvlLoader()
    {
        AbilityLvl = AbilityLoader.AbilityLvl[AbilityIndex] + 1;
    }
}
