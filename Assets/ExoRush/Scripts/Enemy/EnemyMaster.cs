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
    public bool SwitchMap;
    public TransitionAutomaticAnimation SwitchMapTransition;
    public Animator Animator;
    public float HitBetweenTime = 0.1f;
    float TempHitBetweenTime;
    public Material ChangeColorMaterial;
    float LerpValue;

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
        TempHitBetweenTime -= Time.deltaTime;

        if(ChangeColorMaterial != null)
        {
            LerpValue -= Time.deltaTime;

            LerpValue = Mathf.Clamp01(LerpValue);

            ChangeColor(Color.Lerp(Color.blue,Color.red,LerpValue));
        }
    }

    public void Damage(int damage)
    {
        Health -= damage;

        if(Animator != null)
        {
            if(TempHitBetweenTime < 0)
            {
                TempHitBetweenTime = HitBetweenTime;

                Animator.SetTrigger("Hit");
            }

            if (ChangeColorMaterial != null)
            {
                LerpValue += Time.deltaTime * 2;
            }


        }        

        if (Health <= 0)
        {
            if(Animator != null)
            {
                Animator.SetTrigger("Death");
            }

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
            if (SwitchMap)
            {
                SwitchMapTransition.Activate();
            }

        }

        if (HealthBar != null)
        {
            HealthBar.GetComponent<UnityEngine.UI.Image>().fillAmount = (float)Health / (float)MaxHealth;
        }
    }


    public void ChangeColor(Color Color)
    {
        ChangeColorMaterial.SetColor("_EmissionColor", Color);
    }




}
