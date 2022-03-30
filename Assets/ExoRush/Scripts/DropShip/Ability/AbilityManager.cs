using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PowerUps { Laser, Missile, Dash,FusionCannon};

public class AbilityManager : MonoBehaviour
{
    PowerUps PowerUpEarned;

    bool EffectEnabled;

    float AbilityFullDuration;

    float EffectDurationCowntdown;

    MonoBehaviour CurrentPowerUP;

    //UI
    public GameObject TimeBox;

    public GameObject AbilityIcon;

    public GameObject TimeBar;

    private Image IconImage;

    Sprite AbilitySprite;

    //Laser
    public LaserAbility LaserAbiityRef;
    public Sprite LaserIcon;

    //Missile
    public DropShipMissileScript MissileAbilityRef;
    public Sprite MissileIcon;

    //Dash
    public DashBoost DashAbilityRef;
    public Sprite DashIcon;

    //Fusion Cannon
    public FusionCannonAbility FusionAbilityRef;
    public Sprite FusionIcon;



    // Start is called before the first frame update
    void Start()
    {
        IconImage = AbilityIcon.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(EffectDurationCowntdown > 0)
        {

            EffectDurationCowntdown -= Time.deltaTime;

            EffectDurationCowntdown = Mathf.Clamp(EffectDurationCowntdown, 0, AbilityFullDuration);

            TimeBar.GetComponent<UnityEngine.UI.Image>().fillAmount = (float)EffectDurationCowntdown / (float)AbilityFullDuration;
        }
        else
        {
            if (EffectEnabled)
            {
                DisableAbility();
            }
        }


    }

    public void EarnPowerUp(PowerUps PowerUp)
    {
        if (CurrentPowerUP != null)
        {
            AbilityEnabler(false);
        }

        

        switch (PowerUp)
        {
            case PowerUps.Laser:
                CurrentPowerUP = LaserAbiityRef;
                AbilityFullDuration = 3;
                AbilitySprite = LaserIcon;
                break;
            case PowerUps.Missile:
                CurrentPowerUP = MissileAbilityRef;
                AbilityFullDuration = 3;
                AbilitySprite = MissileIcon ;
                break;
            case PowerUps.Dash:
                CurrentPowerUP = DashAbilityRef;
                AbilityFullDuration = 3;
                AbilitySprite = DashIcon;
                break;
            case PowerUps.FusionCannon:
                CurrentPowerUP = FusionAbilityRef;
                AbilityFullDuration = 3;
                AbilitySprite = DashIcon;
                break;
        }

        EffectDurationCowntdown = AbilityFullDuration;

        AbilityEnabler(true);

        EffectEnabled = true;

        TimeBox.SetActive(true);

        AbilityIcon.SetActive(true);

        IconImage.sprite = AbilitySprite;

    }

    public void DisableAbility()
    {
        EffectEnabled = false;

        TimeBox.SetActive(false);

        AbilityIcon.SetActive(false);

        AbilityEnabler(false);
        

    }

    void AbilityEnabler(bool Enabled)
    {

        if(CurrentPowerUP == LaserAbiityRef)
        {
            LaserAbiityRef.CanActivate = Enabled;
        }
        else if(CurrentPowerUP == MissileAbilityRef)
        {
            MissileAbilityRef.CanActivate = Enabled;
        }
        else if(CurrentPowerUP == DashAbilityRef)
        {
            DashAbilityRef.CanActivate = Enabled;
        }
        else if (CurrentPowerUP == FusionAbilityRef)
        {
            FusionAbilityRef.CanActivate = Enabled;
        }

    }

}
