using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWalkAI : MonoBehaviour
{
    public float Xpos;
    public float Zpos;

    public GameObject NPCDest;

    void Start()
    {
        Xpos = Random.Range(transform.position.x - 20, transform.position.x + 20);
        Zpos = Random.Range(transform.position.z - 20, transform.position.z + 20);
        NPCDest.transform.position = new Vector3(Xpos, 35.5f, Zpos);
        StartCoroutine(RunRandomWalk());
    }


    void Update()
    {
        transform.LookAt(NPCDest.transform);
        transform.position = Vector3.MoveTowards(transform.position, NPCDest.transform.position, 0.04f);
    }

    IEnumerator RunRandomWalk()
    {
        yield return new WaitForSeconds(5);
        Xpos = Random.Range(transform.position.x - 20, transform.position.x + 20);
        Zpos = Random.Range(transform.position.z - 20, transform.position.z + 20);
        NPCDest.transform.position = new Vector3(Xpos, 35.5f, Zpos);
        StartCoroutine(RunRandomWalk());
    }
}
