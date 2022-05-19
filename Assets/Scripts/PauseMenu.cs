using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject go_BaseUI;
    [SerializeField] GameObject mouse_sensitivity;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameManager._isPause)
                CallMenu();
            else
                CloseMenu();
        }
    }

    private void CallMenu()
    {
        GameManager._isPause = true;
        go_BaseUI.SetActive(true);
        Time.timeScale = 0f;
    }

    private void CloseMenu()
    {
        GameManager._isPause = false;
        go_BaseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ClickRestart()
    {
        SceneManager.LoadScene(0);
    }

    public void ClickExit()
    {
        Application.Quit();
    }

    public void SetMouseSensitivity(float val)
    {
        if (!Application.isPlaying) return;

        
    }
}
