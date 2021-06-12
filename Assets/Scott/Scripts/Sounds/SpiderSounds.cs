using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSounds : MonoBehaviour
{
    [SerializeField]
    private AudioClip walkSfx, eatSfx, jumpSfx, fallSfx;
    [SerializeField]
    private AudioSource audioSource;

    void Awake()
    {
        if(this.gameObject.GetComponent<AudioSource>())
        {
            audioSource = this.gameObject.GetComponent<AudioSource>();
        }
    }

    public void playWalkSound()
    {
        audioSource.Stop();
        audioSource.clip = walkSfx;
        audioSource.Play();
    }

    public void playJumpSound()
    {
        audioSource.Stop();
        audioSource.clip = jumpSfx;
        audioSource.Play();
    }

    public void playEatSound()
    {
        audioSource.Stop();
        audioSource.clip = eatSfx;
        audioSource.Play();
    }

    public void playFallSound()
    {
        audioSource.Stop();
        audioSource.clip = fallSfx;
        audioSource.Play();
    }
}
