using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject startPanel;
    public PlayerMove playerMove;

    void Start()
    {
        startPanel.SetActive(true);
    }

    public void OnStartButtonClick()
    {
        startPanel.SetActive(false);
        playerMove.canMove = true;
        playerMove.scoreText.gameObject.SetActive(true);
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
}