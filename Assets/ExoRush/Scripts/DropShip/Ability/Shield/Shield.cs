using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    public KeyCode joystickShieldKey = KeyCode.Joystick1Button0;
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

    // Start is called before the first frame update
    void Start()
    {
        Shiled.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(joystickShieldKey))
        {
            

            if(ShieldEnergy > 0 && TempReuseTime <= 0)
            {
                Shiled.SetActive(true);
                Active = true;
                ShieldEnergy -= Time.deltaTime * EnergyDrainedSpeed;
                TempReloadTime = ReloadTime;
            }



            if(ShieldEnergy <= 0)
            {
                Shiled.SetActive(false);
                Active = false;
            }

        }
        else
        {         

            Shiled.SetActive(false);
            Active = false;
        }

        if (TempReloadTime <= 0 && !Active)
        {
            ShieldEnergy += Time.deltaTime * EnergyRegenerateSpeed;
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
}
