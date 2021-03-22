/* Handles all audio within game.
 * PlaySound functions will be 
 * called and play the correct sound
 * abstractly to the caller.
 */
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip hitSoundlvl1;
    public AudioClip hitSoundlvl2;
    public AudioClip hitSoundlvl3;

    public Counter counterScript;

    //Function for sound when ball hits paddle
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
