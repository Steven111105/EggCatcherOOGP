using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip eggSFX;
    [SerializeField] AudioClip bombSFX;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayEggSFX()
    {
        audioSource.PlayOneShot(eggSFX);
    }

    public void PlayBombSFX()
    {
        audioSource.PlayOneShot(bombSFX);
    }
}
