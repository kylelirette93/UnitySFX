using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayback : MonoBehaviour
{
    public AudioSource music;

    void OnTriggerEnter(Collider other)
    {
        music.Pause();
    }

    private void OnTriggerExit(Collider other)
    {
        music.UnPause();
    }
}
