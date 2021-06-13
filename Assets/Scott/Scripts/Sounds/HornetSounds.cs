using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornetSounds : MonoBehaviour
{
    [SerializeField]
    private AudioClip buzzSfx, stingSfx;
    [SerializeField]
    private AudioSource audioSource;

    void Awake()
    {
        if(this.gameObject.GetComponent<AudioSource>())
        {
            audioSource = this.gameObject.GetComponent<AudioSource>();
        }
    }

    public void playBuzzSound()
    {
        audioSource.Stop();
        audioSource.clip = buzzSfx;
        audioSource.Play();
    }

    public void playStingSound()
    {
        audioSource.Stop();
        audioSource.clip = stingSfx;
        audioSource.Play();
    }
}
