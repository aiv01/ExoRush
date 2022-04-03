using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCallFunction : MonoBehaviour, IMenuInteractable
{
   public GameObject executable;
   public void Execute()
    {
        executable.GetComponent<IMenuInteractable>().Execute();
    }
}
