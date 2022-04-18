using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInputCatcher : MonoBehaviour
{
    [SerializeField] private KeyCode[] keys;
    private IMenuInteractable target;

    private void OnEnable()
    {
        target = GetComponent<IMenuInteractable>();
    }

    private void OnDisable()
    {
        target = null;
    }

    void Update()
    {
        foreach (var key in keys)
        {
            if (Input.GetKeyDown(key)) target.Execute();    
        }
    }
}
