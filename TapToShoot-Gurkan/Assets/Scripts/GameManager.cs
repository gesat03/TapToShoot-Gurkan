using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public SceneManager sceneManager;
    public UIManager uIManager;


    private void Start()
    {
        uIManager.OpeningUI();
    }

    private void Update()
    {
        sceneManager.ProjectileMotion();

        LevelCompleted();
    }

    private void LevelCompleted()
    {
        if(sceneManager.colorfulBlockCounter <= 0 && sceneManager.gameStarted)
        {
            sceneManager.LevelCompletedSM();
            uIManager.LevelCompletedUI();
        }
    }

}
