using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRocket : MonoBehaviour
{
    public AudioSource rocketSound;
    public ParticleSystem thrusterParticles;
    public GameObject clusterMissle;
    
    private void OnTriggerEnter(Collider other)
    {
        rocketSound.Play();
        thrusterParticles.Play();
        ActivateLaunch();
    }

    void ActivateLaunch()
    {
        Launch launchScript = clusterMissle.GetComponent<Launch>();
        launchScript.enabled = true;
    }
}
