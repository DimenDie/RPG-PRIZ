using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC001 : MonoBehaviour
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
        if(QuestManager.ActiveQuestNumber == 2)
        {
            TextBox.SetActive(true);
            NPCName.GetComponent<TextMeshProUGUI>().text = "Skeleton";
            NPCName.SetActive(true);
            NPCText.GetComponent<TextMeshProUGUI>().text = "We have a spider problem. Can you go outside the village, kill the spiders and their boss. Here is the key.";
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
            NPCText.GetComponent<TextMeshProUGUI>().text = "Hello friend, I may have a quest for you if you wish to accept it. Please come back later on this afternoon.";
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
