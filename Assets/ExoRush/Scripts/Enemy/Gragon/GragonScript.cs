using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GragonScript : MonoBehaviour
{
    GameObject Ship;
    public float EngageDistance;
    public Animator Animator;
    bool HasDamaged;
    public GameObject StaticRock;
    public GameObject Debris;
    public bool AnimationActivated;
    public AudioSource AttackSound;
    public AudioSource RockSound;

    // Start is called before the first frame update
    void Start()
    {
        Ship = Object.FindObjectOfType<DropShipMovement>().gameObject;

        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z - EngageDistance < Ship.transform.position.z && !AnimationActivated)
        {
            Animator.enabled = true;
            StaticRock.SetActive(false);
            Debris.SetActive(true);
            if (!AnimationActivated)
            {
                AttackSound.Play();
                RockSound.Play();
            }
            AnimationActivated = true;

            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!HasDamaged && other.name == "Dropship")
        {
            Object.FindObjectOfType<InGameHealth>().Damage(200, true, false, false);
            HasDamaged = true;
        }

    }
}
