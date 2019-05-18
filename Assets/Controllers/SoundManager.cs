using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioClip shotSE;
    public AudioClip damageSE;
    public AudioClip healSE;
    public AudioClip getAmmoSE;
    public AudioClip hitSE;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void playShotSE()
    {
        audioSource.clip = shotSE;
        audioSource.Play();
    }

    public void playHitSE()
    {
        audioSource.clip = hitSE;
        audioSource.Play();
    }
}
