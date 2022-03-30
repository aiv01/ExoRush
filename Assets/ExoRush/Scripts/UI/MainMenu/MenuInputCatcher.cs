using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInputCatcher : MonoBehaviour
{
    [SerializeField] private KeyCode[] keys;
    private IMenuInteractable target;

    private void Awake()
    {
        target = GetComponent<IMenuInteractable>();
    }

    void Update()
    {
        foreach (var key in keys)
        {
            if (Input.GetKeyDown(key)) target.Execute();
        }
    }
}
