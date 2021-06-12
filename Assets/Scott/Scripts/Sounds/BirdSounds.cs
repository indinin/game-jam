using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSounds : MonoBehaviour
{
    [SerializeField]
    private AudioClip warningSfx, flapSfx;
    [SerializeField]
    private AudioSource audioSource;

    void Awake()
    {
        if(this.gameObject.GetComponent<AudioSource>())
        {
            audioSource = this.gameObject.GetComponent<AudioSource>();
        }
    }

    public void playWarningSound()
    {
        audioSource.Stop();
        audioSource.clip = warningSfx;
        audioSource.Play();
    }

    public void playFlapSound()
    {
        audioSource.Stop();
        audioSource.clip = flapSfx;
        audioSource.Play();
    }
}
