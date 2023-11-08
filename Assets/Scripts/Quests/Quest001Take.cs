using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Quest001Take : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject UIQuest;
    public GameObject ThePlayer;
    public GameObject NoticeCam;
    public GameObject MiniMap;
    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 3)
        {
            AttackBlocker.BlockSword = 1;
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }

        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 3)
            {
                MiniMap.SetActive(false);
                AttackBlocker.BlockSword = 2;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                UIQuest.SetActive(true);
                NoticeCam.SetActive(true);
                ThePlayer.SetActive(false);
            }
        }
    }

    void OnMouseExit()
    {
        AttackBlocker.BlockSword = 0;
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }
}
