using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLaunch : MonoBehaviour
{
    public AudioSource rocketSound;
    public ParticleSystem thrusterParticles;
    public GameObject clusterMissle;
    float launchSpeed = 5f;
    private void OnTriggerEnter(Collider other)
    {
        rocketSound.Play();
        thrusterParticles.Play();
        LaunchMissle();
    }

    void LaunchMissle()
    {
       
            clusterMissle.transform.position = transform.position + new Vector3(transform.position.x, launchSpeed * Time.deltaTime, transform.position.z);
        
    }
}
