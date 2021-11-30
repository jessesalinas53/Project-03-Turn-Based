using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip damageAudio;
    static AudioSource audioSource;

    private void Start()
    {
        damageAudio = Resources.Load<AudioClip>("damageAudio");
        audioSource = GetComponent<AudioSource>();
    }

    public static void playDamageAudio()
    {
        //audioSource.PlayOneShot(damageAudio);
    }
}
