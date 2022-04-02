using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameHealth : MonoBehaviour
{
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

    //Death
    public GameObject DeadShipModel;
    private GameObject DeadShip;
    public FadeAudioEffect AudioManager;
    public float AudioFadeOutDuration = 2;

    //Sound
    public AudioSource ImpactAudio;
    public AudioSource DeathAudio;



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

    }

    // Update is called once per frame
    void LateUpdate()
    {
        FixHealth();
    }

    public void Damage(int damage,bool Shieldable,bool SpeedReduction,bool ShakeCamera)
    {
        if (Shieldable && ShiledScript.Active)
        {
            Object.FindObjectOfType<InGameScoreCalculation>().AdditionalScore(damage);
            damage = 0;            
        }
        HealAfterCounter = HealAfterTimer;
        Health = Health - damage;
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
            if(DeathAudio != null)
            {
                DeathAudio.Play();
            }

            if(AbilityManager != null)
            {
                AbilityManager.DisableAbility();
            }

            if(AudioManager != null)
            {
                AudioManager.FadeOUT(AudioFadeOutDuration);
            }

            DeadShip = Instantiate(DeadShipModel, transform.position, transform.rotation);

            gameObject.SetActive(false);

            DeadShip.GetComponent<Rigidbody>().velocity = new Vector3(DropShipMovementScript.RotTarget * -1, 0, DropShipMovementScript.CurrentVelocity * 10);

            
            
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

        HealthBar.GetComponent<UnityEngine.UI.Image>().fillAmount = (float)Health / (float)MaxHealth;
    }


}
