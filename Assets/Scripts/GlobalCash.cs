using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GlobalCash : MonoBehaviour
{
    public static int GoldAmount;
    public int InternalGold;
    public GameObject GoldDisplay;

    void Update()
    {
        InternalGold = GoldAmount;
        GoldDisplay.GetComponent<TextMeshProUGUI>().text = "GOLD: " + InternalGold;
    }
}
