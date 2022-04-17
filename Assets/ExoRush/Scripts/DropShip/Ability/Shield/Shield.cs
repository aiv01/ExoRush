using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject Shiled;
    public bool Active;
    float ShieldEnergy = 1;
    public float EnergyDrainedSpeed;
    public float EnergyRegenerateSpeed;
    public float ReloadTime;
    float TempReloadTime;
    public float ReuseTime;
    float TempReuseTime;
    public GameObject ShieldBar;

    public MeshCollider ShieldMeshCollider;

    //LVL
    public LIVDefMap AbilityLoader;
    int AbilityLvl;
    public int AbilityIndex;

    //Particles


    // Start is called before the first frame update
    void Start()
    {
        AbilityLvlLoader();

        Shiled.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Shield"))
        {

            if(ShieldEnergy > 0 && TempReuseTime <= 0)
            {
                ActivateShield(true);

                ShieldEnergy -= (Time.deltaTime * EnergyDrainedSpeed) / AbilityLvl;
                TempReloadTime = ReloadTime;
            }



            if(ShieldEnergy <= 0)
            {
                ActivateShield(false);
            }

        }
        else
        {
            ActivateShield(false);
        }

        if (TempReloadTime <= 0 && !Active)
        {
            ShieldEnergy += Time.deltaTime * EnergyRegenerateSpeed * AbilityLvl;
        }
        else
        {
            TempReloadTime -= Time.deltaTime;
        }


        if (ShieldEnergy <= 0 && TempReuseTime <= 0)
        {
            TempReuseTime = ReuseTime;
        }
        else
        {
            TempReuseTime -= Time.deltaTime;
        }

        ShieldEnergy = Mathf.Clamp(ShieldEnergy, 0, 1);

        ShieldBar.GetComponent<UnityEngine.UI.Image>().fillAmount = (float)ShieldEnergy;
    }

    public void AbilityLvlLoader()
    {
        AbilityLvl = AbilityLoader.AbilityLvl[AbilityIndex] + 1;
    }

    public void ActivateShield(bool Activate)
    {
        if (Activate)
        {
            Shiled.SetActive(true);
            Active = true;
        }
        else
        {
            Shiled.SetActive(false);
            Active = false;
        }
    }
}
