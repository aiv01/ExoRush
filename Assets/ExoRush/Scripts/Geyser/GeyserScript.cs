using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeyserScript : MonoBehaviour
{
    public GameObject MainGeyserParticle;
    public GameObject WarningGeyserParticle;
    public GameObject MainDamageBox;
    public GameObject WarningDamageBox;
    bool WarningActive;
    bool MainActive;
    public float MainActivationTime;
    float TempMainActivationTime;
    public float MainGeyserDuration;
    float TempMainGeyeserDuration;
    public float ReloadTime;
    float TempReloadTime;
    public BoxCollider DetectBoxCollider;
    public GeyserDamageScript DamageScript;

    void Start()
    {
        
    }

    void Update()
    {
        if (WarningActive)
        {
            TempMainActivationTime -= Time.deltaTime;
            if(TempMainActivationTime < 0)
            {
                StartMain();
            }
        }

        if (MainActive)
        {
            TempMainGeyeserDuration -= Time.deltaTime;
            if(TempMainGeyeserDuration < 0)
            {
                MainActive = false;
                MainGeyserParticle.SetActive(false);
                MainDamageBox.SetActive(false);
                
            }
        }


        if(!WarningActive && !MainActive)
        {
            TempReloadTime -= Time.deltaTime;
            if(TempReloadTime < 0)
            {
                DetectBoxCollider.enabled = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(TempReloadTime < 0)
        {
            WarningGeyser();
            TempMainGeyeserDuration = MainGeyserDuration;
            DetectBoxCollider.enabled = false;
        }
            

    }

    private void WarningGeyser()
    {
        WarningActive = true;
        WarningGeyserParticle.SetActive(true);
        TempMainActivationTime = MainActivationTime;       
        
    }

    private void StartMain()
    {
        WarningGeyserParticle.SetActive(false);
        MainGeyserParticle.SetActive(true);
        TempReloadTime = ReloadTime;
        WarningActive =false;
        MainActive = true;
        MainDamageBox.SetActive(true);
        DamageScript.Player = null;
        
        
    }


}
