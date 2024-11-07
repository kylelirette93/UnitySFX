using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{
    float speed = 0.0001f;
    float timeSinceLaunch;
    ParticleSystem particleSystem;
    ParticleSystem.MainModule main;
    ParticleSystem.ShapeModule shape;

    void Start()
    {
        // Access modules of particle system.
        particleSystem = GetComponent<ParticleSystem>();
        main = particleSystem.main;
        shape = particleSystem.shape;
    }

    void Update()
    {
        timeSinceLaunch += Time.deltaTime;

        if (timeSinceLaunch > 2.5f)
        {
            // Modify particle system to simulate acceleration.
            main.startSpeed = 0;
            main.simulationSpeed = 1;
            main.startLifetime = 0.3f;
            shape.arc = 20;
            speed += 0.01f;
        }

        // Apply movement to the particle system, with an exponential increase.
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        speed += 0.0001f;

        // Limit the speed from going to fast.
        speed = Mathf.Clamp(speed, 1, 10);

        if (transform.position.y >= 100f)
        {
            // Get rid of the rocket when you can no longer see it.
            Destroy(gameObject);
        }
    }
}
