using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ledge001 : MonoBehaviour
{
    public GameObject theLedge;
    public GameObject thePlayer;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            thePlayer.transform.parent = theLedge.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            thePlayer.transform.parent = null;
        }
    }
}
