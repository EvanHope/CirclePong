using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip hitSoundlvl1;
    public AudioClip hitSoundlvl2;
    public AudioClip hitSoundlvl3;

    public Counter counterScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayHitSound()
    {
        if (counterScript.score < 25)
            audioSource.PlayOneShot(hitSoundlvl1);
        else if (counterScript.score >= 25 && counterScript.score < 100)
            audioSource.PlayOneShot(hitSoundlvl2);
        else if (counterScript.score >= 100)
            audioSource.PlayOneShot(hitSoundlvl3);
    }
}
