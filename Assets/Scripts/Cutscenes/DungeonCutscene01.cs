using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCutscene01 : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject cutCam;
    public GameObject cutBars;
    public GameObject theCursor;
    public GameObject miniMap;
    public GameObject fadeIn;
    public GameObject fadeOut;
    public GameObject skeletonObject;
    public GameObject skeletonBoss;

    void OnTriggerEnter(Collider other)
    {
        this.GetComponent<BoxCollider>().enabled = false;
        fadeOut.SetActive(true);
        StartCoroutine(SkeletonCut());
    }

    IEnumerator SkeletonCut()
    {
        yield return new WaitForSeconds(2);
        fadeOut.SetActive(false);
        cutCam.SetActive(true);
        cutBars.SetActive(true);
        thePlayer.SetActive(false);
        theCursor.SetActive(false);
        miniMap.SetActive(false);
        fadeIn.GetComponent<Animation>().Play("FadeInAnimation");
        yield return new WaitForSeconds(6);
        fadeOut.SetActive(true);
        fadeOut.GetComponent<Animation>().Play("FadeOutAnimation");
        yield return new WaitForSeconds(2);
        thePlayer.SetActive(true);
        cutCam.SetActive(false);
        cutBars.SetActive(false);
        theCursor.SetActive(true);
        miniMap.SetActive(true);
        skeletonObject.GetComponent<SpiderBossAI>().enabled = true;
        skeletonObject.GetComponent<SkeletonAttack>().enabled = true;
        skeletonBoss.GetComponent<Animator>().Play("Walk");
        fadeOut.SetActive(false);
    }
}
