using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeyserDamageScript : MonoBehaviour
{
    public int Damage;
    public GameObject Player;
    public float TimeBetweenDamge;
    float TempTimeBetweenDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Player != null)
        {
            if(TempTimeBetweenDamage > TimeBetweenDamge) 
            {
                TempTimeBetweenDamage = 0;
                Player.GetComponent<InGameHealth>().Damage(Damage, false, false, false);
            }
            TempTimeBetweenDamage += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player = other.gameObject;
            TempTimeBetweenDamage = TimeBetweenDamge;
        }
          
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Player = null;
        }
    }
}
