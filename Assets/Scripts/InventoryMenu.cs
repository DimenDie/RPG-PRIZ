using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    public bool invOpen = false;
    public GameObject invMenu;
    public GameObject thePlayer;
    public GameObject itemPanel;
    public GameObject questPanel;
    public GameObject statPanel;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (invOpen == false)
            {
                Time.timeScale = 0;
                invOpen = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                invMenu.SetActive(true);
                thePlayer.GetComponent<PlayerController>().enabled = false;
            }
            else
            {
                thePlayer.GetComponent<PlayerController>().enabled = true;
                invMenu.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                invOpen = false;
                Time.timeScale = 1;
            }
        }
    }
    public void ShowItem()
    {
        itemPanel.SetActive(true);
        questPanel.SetActive(false);
        statPanel.SetActive(false);
    }
    public void ShowQuest()
    {
        itemPanel.SetActive(false);
        questPanel.SetActive(true);
        statPanel.SetActive(false);
    }
    public void ShowStat()
    {
        itemPanel.SetActive(false);
        questPanel.SetActive(false);
        statPanel.SetActive(true);
    }

    public void CloseMenu()
    {
        thePlayer.GetComponent<PlayerController>().enabled = true;
        invMenu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        invOpen = false;
        Time.timeScale = 1;
    }
}
