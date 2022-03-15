using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaster : MonoBehaviour
{
    public EnemyMasterRagdoll RagdollReference;
    public int MaxHealth = 1;
    int Health;

    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int damage)
    {
        Health -= damage;

        if(Health <= 0)
        {
            RagdollReference.Replace();
        }
    }


}
