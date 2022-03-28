using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokenLogic : MonoBehaviour
{
    [SerializeField] private Sprite idleImage;
    [SerializeField] private Sprite activeImage;
    private Image currentImage = null;
    private bool activeStatus = false;
    private void Awake()
    {
        currentImage = GetComponent<Image>();
    }

    public bool ActiveStatus
    {
        get { return activeStatus; }
        set 
        { 
            if (value && !activeStatus)
            {
                activeStatus = true;
                currentImage.sprite = activeImage;
            } else if (!value && activeStatus)
            {
                activeStatus = false;
                currentImage.sprite = idleImage;
            }
        }
    }
}
