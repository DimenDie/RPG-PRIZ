using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollect : MonoBehaviour
{
    [SerializeField] int rotateSpeed;
    public AudioSource collectSound;

    void Update()
    {
        rotateSpeed = 2;
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }

    void OnTriggerEnter()
    {
        collectSound.Play();
        HealthMonitor.healthValue += 1;
        gameObject.SetActive(false);
    }
}