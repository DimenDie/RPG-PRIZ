using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class NPC001_Comp : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ThePlayer;
    public GameObject TextBox;
    public GameObject NPCName;
    public GameObject NPCText;


    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 3)
        {
            AttackBlocker.BlockSword = 1;
            ActionText.GetComponent<TextMeshProUGUI>().text = "Talk";
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }

        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 3)
            {
                AttackBlocker.BlockSword = 2;
                Screen.lockCursor = false;
                Cursor.visible = true;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                //ThePlayer.SetActive (false);
                StartCoroutine(NPC001Active());
            }
        }
    }

    void OnMouseExit()
    {
        AttackBlocker.BlockSword = 0;
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }

    IEnumerator NPC001Active()
    {
        if (QuestManager.ActiveQuestNumber == 2 && QuestManager.SubQuestNumber == 4)
        {
            TextBox.SetActive(true);
            NPCName.GetComponent<TextMeshProUGUI>().text = "Skeleton";
            NPCName.SetActive(true);
            NPCText.GetComponent<TextMeshProUGUI>().text = "Thank you very much for your help. There is a cave outside the village, please go explore.";
            QuestManager.ActiveQuestNumber = 3;
            QuestManager.SubQuestNumber = 1;
            NPCText.SetActive(true);
            yield return new WaitForSeconds(5.5f);
            NPCName.SetActive(false);
            NPCText.SetActive(false);
            TextBox.SetActive(false);
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }
        else
        {
            TextBox.SetActive(true);
            NPCName.GetComponent<TextMeshProUGUI>().text = "Skeleton";
            NPCName.SetActive(true);
            NPCText.GetComponent<TextMeshProUGUI>().text = "Please come and see me when you have explored the cave.";
            NPCText.SetActive(true);
            yield return new WaitForSeconds(5.5f);
            NPCName.SetActive(false);
            NPCText.SetActive(false);
            TextBox.SetActive(false);
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }
    }
}
