using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLogic : MonoBehaviour
{
    [SerializeField] private AudioClip[] purchaseClips;

    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayPurchaseClip()
    {
        int randomIndex = Random.Range(0, purchaseClips.Length);
        source.clip = purchaseClips[randomIndex];
        source.Play();
    }
}
