using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalExp : MonoBehaviour
{
    public static int CurrentExp;
    public int InternalExp;

    public GameObject xpBar;
    void Update()
    {
        InternalExp = CurrentExp;
        xpBar.GetComponent<Slider>().value = InternalExp;
    }
}
