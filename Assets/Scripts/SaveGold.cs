using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGold : MonoBehaviour
{
    public int LoadGold;
    void Start()
    {
        LoadGold = PlayerPrefs.GetInt("GoldAmountSave");
    }
}
