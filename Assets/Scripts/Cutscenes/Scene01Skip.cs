using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene01Skip : MonoBehaviour
{
    public GameObject FadeIn;
    private void Start()
    {
        StartCoroutine(FadeQuit());
    }

    IEnumerator FadeQuit()
    {
        yield return new WaitForSeconds(1);
        FadeIn.SetActive(false);
    }
}
