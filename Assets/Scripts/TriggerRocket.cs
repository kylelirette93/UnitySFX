using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRocket : MonoBehaviour
{
    public AudioSource rocketSound;
    public ParticleSystem thrusterParticles;
    public GameObject clusterMissle;
    float timeSinceLaunch;
    
    private void OnTriggerEnter(Collider other)
    {
        // Activate the sound and the particle system.
        rocketSound.Play();
        thrusterParticles.Play();
        
        // Launch the rocket.
        ActivateLaunch();
    }

    void ActivateLaunch()
    {
        Launch launchScript = clusterMissle.GetComponent<Launch>();
        launchScript.enabled = true;
    }
}
