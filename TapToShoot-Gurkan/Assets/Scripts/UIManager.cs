using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject openingPanel;
    public GameObject winPanel;


    public void OpeningUI()
    {
        openingPanel.SetActive(true);

        winPanel.SetActive(false);
    }

    public void GamePlayUI()
    {
        openingPanel.SetActive(false);

        winPanel.SetActive(false);
    }

    public void LevelCompletedUI()
    {
        winPanel.SetActive(true);
    }

}
