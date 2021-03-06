using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class InGameHealth : MonoBehaviour
{
    public LIV liv;
    public GameObject EndMenu;
    public GameObject PauseMenu;
    public float EndMenuTimer = 2.0f;
    public GameObject shipModel;
    public int MaxHealth = 100;
    int Health;
    public GameObject HealthBar;
    public float HealAfterTimer = 5;
    public int HealAfterAmount = 5;
    float HealAfterCounter;
    public float HealInterval = 0.1f;
    float HealIntervalCounter;
    public Shield ShiledScript;
    public AbilityManager AbilityManager;

    public CameraMovementScript CameraScript;
    public DropShipMovement DropShipMovementScript;

    public Volume DamageVolume;
    public Volume HitVolume;
    public AnimationCurve HitPostProcessAnimation;
    public float HitAnimationSpeed = 1;
    bool HitAnimationInProgress;
    float TempAnimationPosition;

    //Death
    public GameObject DeadShipModel;
    private GameObject DeadShip;
    public FadeAudioEffect AudioManager;
    public float AudioFadeOutDuration = 2;

    //Sound
    public AudioSource ImpactAudio;
    public AudioSource DeathAudio;

    //Inulnerability
    public float InvulnerabilityTimeFrame = 0.2f;
    float TempInvulnerabiliy;

    public bool DashInvulnerability;
    public bool DeadShipSpawned;

    public bool BossMap;

   

    private void Awake()
    {
        shipModel.SetActive(true);
        EndMenu.SetActive(false);
        PauseMenu.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
    }

    private void Update()
    {
        HealAfterCounter = HealAfterCounter - Time.deltaTime;
        HealIntervalCounter = HealIntervalCounter - Time.deltaTime;

        if(HealAfterCounter <= 0 && HealIntervalCounter <= 0)
        {
            HealAfterCounter = HealInterval;
            Health += HealAfterAmount;
        }

        InvulnerabilityTimeFrame -= Time.deltaTime;

        if (HitAnimationInProgress)
        {
            TempAnimationPosition += Time.deltaTime * HitAnimationSpeed;

            HitVolume.weight = HitPostProcessAnimation.Evaluate(TempAnimationPosition);

            if (TempAnimationPosition > 1)
            {
                HitAnimationInProgress = false;
            }
        }

    }

    // Update is called once per frame
    void LateUpdate()
    {
        FixHealth();
    }

    public void Damage(int damage,bool Shieldable,bool SpeedReduction,bool ShakeCamera)
    {

        if(TempInvulnerabiliy > 0 || DashInvulnerability == true)
        {
            damage = 0;
        }



        TempInvulnerabiliy = InvulnerabilityTimeFrame;

        if (Shieldable && ShiledScript.Active)
        {
            Object.FindObjectOfType<InGameScoreCalculation>().AdditionalScore(damage);
            damage = 0;            
        }
        HealAfterCounter = HealAfterTimer;
        Health = Health - damage;

        if (damage > 0 && !HitAnimationInProgress)
        {
            HitAnimationInProgress = true;
            TempAnimationPosition = 0;
        }

        if (ShakeCamera)
        {
            CameraScript.ShakeCamera();
            ImpactAudio.Play();
        }
        if (SpeedReduction)
        {
            DropShipMovementScript.DamagingCollision();
        }

        FixHealth();

        if(Health <= 0)
        {
            InGameScoreCalculation.TransitionMapScore = 0;

            if(AbilityManager != null)
            {
                AbilityManager.DisableAbility();
            }

            if(AudioManager != null)
            {
                AudioManager.FadeOUT(AudioFadeOutDuration);
            }

            if (!DeadShipSpawned)
            {
                DeadShipSpawned = true;
                DeadShip = Instantiate(DeadShipModel, transform.position, transform.rotation);

                if(BossMap == true)
                {
                    AudioSource[] AudioComponents = Resources.FindObjectsOfTypeAll<AudioSource>();
                    for (int i = 0; i < AudioComponents.Length; i++)
                    {
                        if (AudioComponents[i].transform.gameObject.transform.tag != "BackgroundMusic")
                        {
                            AudioComponents[i].enabled = false;
                        }

                    }
                    if (DeathAudio != null)
                    {
                        DeathAudio.enabled = true;
                        DeathAudio.Play();
                    }
                }


            }



            if (DropShipMovementScript != null)
            {
                DeadShip.GetComponent<Rigidbody>().velocity = new Vector3(DropShipMovementScript.RotTarget * -1, 0, DropShipMovementScript.CurrentVelocity * 10);
            }

            DeadShip.AddComponent<EndMenuLogic>();

            liv.UpdateSelected(false, false, false, true);
            DeadShip.GetComponent<EndMenuLogic>().Initialise(EndMenu, PauseMenu, EndMenuTimer);
            DeadShip.GetComponent<EndMenuLogic>().StartCounter();
            gameObject.SetActive(false);


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            Damage(400,false,true,true);
        }
        else if(other.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyMaster>().Damage(50);
            
        }

    }

   public void FixHealth()
    {
        Health = Mathf.Clamp(Health, 0, MaxHealth);

        if(DamageVolume != null)
        {
            DamageVolume.weight = ((float)Health / (float)MaxHealth) * -1 + 0.5f;
        }
        

        HealthBar.GetComponent<UnityEngine.UI.Image>().fillAmount = (float)Health / (float)MaxHealth;

        
        
    }


}
