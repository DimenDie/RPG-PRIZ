using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MasterQuest : MonoBehaviour
{
    public GameObject mainQuestText;
    public GameObject mainQuestDesc;
    public static string mainQuestName;
    public static string mainQuestInfo;

    void Update()
    {
        mainQuestText.GetComponent<TextMeshProUGUI>().text = mainQuestName;
        mainQuestDesc.GetComponent<TextMeshProUGUI>().text = mainQuestInfo;
    }
}
