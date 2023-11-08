using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthMonitor : MonoBehaviour
{
    public static int healthValue;
    public int internalHealth;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    void Start()
    {
        healthValue = 1;
    }


    void Update()
    {
        internalHealth = healthValue;

        if(healthValue <= 0)
        {
            SceneManager.LoadScene(2);
        }

        if (healthValue == 1)
        {
            heart1.SetActive(true);
            heart2.SetActive(false);
        }
        if (healthValue == 2)
        {
            heart2.SetActive(true);
            heart3.SetActive(false);
        }
        if (healthValue == 3)
        {
            heart3.SetActive(true);
        }

    }
}
