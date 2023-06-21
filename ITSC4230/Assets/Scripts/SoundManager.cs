using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource source;

    private void Start() {
        source = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip) {
        source.PlayOneShot(clip);
    }

}
