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
        if(HealthMonitor.healthValue == 300)
        {
            //add extra spin
            return;
        }
        collectSound.Play();
        HealthMonitor.healthValue += 20;
        gameObject.SetActive(false);
    }
}