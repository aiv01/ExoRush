using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestruction : MonoBehaviour
{
    public MeshRenderer PhysicalBox;
    public GameObject DestructibleBox;
    GameObject DropShip;
    AbilityManager AbilityManager;
    public PowerUps PowerUp;
    public bool ForcedPowerup;


    // Start is called before the first frame update
    void Start()
    {
        if (!ForcedPowerup)
        {
            System.Array A = System.Enum.GetValues(typeof(PowerUps));
            PowerUp = (PowerUps)A.GetValue(UnityEngine.Random.Range(0, A.Length));
        }

    }

    public void DestroyBox()
    {
        PhysicalBox.enabled = false;
        DestructibleBox.SetActive(true);
        DropShip = GameObject.FindGameObjectWithTag("Player");
        AbilityManager = DropShip.GetComponent<AbilityManager>();
        AbilityManager.EarnPowerUp(PowerUp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
