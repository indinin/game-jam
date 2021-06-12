using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebSounds : MonoBehaviour
{
    [SerializeField]
    private AudioClip thwipSfx, snapSfx;
    [SerializeField]
    private AudioSource audioSource;

    void Awake()
    {
        if(this.gameObject.GetComponent<AudioSource>())
        {
            audioSource = this.gameObject.GetComponent<AudioSource>();
        }
    }

    public void playThwipSound()
    {
        audioSource.Stop();
        audioSource.clip = thwipSfx;
        audioSource.Play();
    }

    public void playSnapSound()
    {
        audioSource.Stop();
        audioSource.clip = snapSfx;
        audioSource.Play();
    }
}
