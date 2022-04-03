using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChromperBaseScript : MonoBehaviour
{
    GameObject Ship;
    public float AttackRadius;
    public float SpotRadius;
    public float DamageRadius;
    public Animator ChompAnimator;
    bool HasDamaged;
    public AudioSource AttackSound;
    public bool SoundStarted;

    public float DestroyOffset;

    // Start is called before the first frame update
    void Start()
    {
        Ship = Object.FindObjectOfType<DropShipMovement>().gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, Ship.transform.position) < SpotRadius)
        {
            ChompAnimator.SetTrigger("Spotted");
            
        }

        if(Vector3.Distance(transform.position,Ship.transform.position) < AttackRadius)
        {
            
            
            if (!SoundStarted)
            {
                AttackSound.Play();
                ChompAnimator.SetTrigger("Attack");
            }

            SoundStarted = true;
            
        }

        if (Vector3.Distance(transform.position, Ship.transform.position) < DamageRadius && !HasDamaged)
        {
            Object.FindObjectOfType<InGameHealth>().Damage(200,true,false,false);
            HasDamaged = true;
        }

        CheckIfBehind();

        //Debug.Log(Vector3.Distance(transform.position, Ship.transform.position));
    }

    public void CheckIfBehind()
    {
        if(transform.position.z < Ship.transform.position.z + DestroyOffset)
        {
            Destroy(this.gameObject);
        }

    }

}
