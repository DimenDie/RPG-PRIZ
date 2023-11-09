using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeRespawn : MonoBehaviour
{
    public GameObject fadeIn;
    public GameObject thePlayer;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            thePlayer.transform.position = new Vector3(813.87f, -20.86f, 192.12f);
            fadeIn.GetComponent<Animation>().Play("FadeInAnimation");
        }
    }
}
