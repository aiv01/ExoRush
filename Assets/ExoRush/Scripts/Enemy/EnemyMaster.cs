using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaster : MonoBehaviour
{
    public EnemyMasterRagdoll RagdollReference;
    public int MaxHealth = 1;
    int Health;
    public GameObject HealthBar;
    public BoxDestruction BoxDestruction;

    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;

        if(HealthBar != null)
        {
            HealthBar.GetComponent<UnityEngine.UI.Image>().fillAmount = (float)MaxHealth;
        }
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
            if(RagdollReference != null)
            {
                RagdollReference.Replace();
            }
            else if(BoxDestruction != null)
            {
                BoxDestruction.DestroyBox();
            }
            else
            {
                Destroy(this);
            }


        }

        if (HealthBar != null)
        {
            HealthBar.GetComponent<UnityEngine.UI.Image>().fillAmount = (float)Health / (float)MaxHealth;
        }
    }


}
