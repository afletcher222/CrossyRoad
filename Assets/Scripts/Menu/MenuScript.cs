using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject startPanel;
    public PlayerMove playerMove;

    // Start is called before the first frame update
    void Start()
    {
        startPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
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
