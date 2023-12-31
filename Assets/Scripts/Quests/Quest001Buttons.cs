using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quest001Buttons : MonoBehaviour
{
    public GameObject ThePlayer;
    public GameObject NoticeCam;
    public GameObject UIQuest;
    public GameObject ActiveQuestBox;
    public GameObject Objective01;
    public GameObject Objective02;
    public GameObject Objective03;
    public GameObject ExMark;
    public GameObject TheNotice;
    public GameObject NoticeTrigger;
    public GameObject MiniMap;

    public void AcceptQuest()
    {
        MiniMap.SetActive(true);
        QuestManager.SubQuestNumber = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ThePlayer.SetActive(true);
        NoticeCam.SetActive(false);
        UIQuest.SetActive(false);
        StartCoroutine(SetQuestUI());
    }

    IEnumerator SetQuestUI()
    {
        ExMark.SetActive(false);
        TheNotice.SetActive(false);
        NoticeTrigger.SetActive(false);
        ActiveQuestBox.GetComponent<TextMeshProUGUI>().text = "My First Weapon";
        Objective01.GetComponent<TextMeshProUGUI>().text = "Reach the clearing in the wood";
        Objective02.GetComponent<TextMeshProUGUI>().text = "Open the chest";
        Objective03.GetComponent<TextMeshProUGUI>().text = "Retrieve the weapon";
        QuestManager.ActiveQuestNumber = 1;
        yield return new WaitForSeconds(0.5f);
        ActiveQuestBox.SetActive(true);
        yield return new WaitForSeconds(1);
        Objective01.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Objective02.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Objective03.SetActive(true);
        yield return new WaitForSeconds(9);
        ActiveQuestBox.SetActive(false);
        Objective01.SetActive(false);
        Objective02.SetActive(false);
        Objective03.SetActive(false);
    }

    public void DeclineQuest()
    {
        MiniMap.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ThePlayer.SetActive(true);
        NoticeCam.SetActive(false);
        UIQuest.SetActive(false);
    }
}
