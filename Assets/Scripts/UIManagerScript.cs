using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour
{
    GameObject MenuPanel;
    GameObject SettingsPanel;
    GameObject GamePanel;
    GameObject PausePanel;
    GameObject GameOverPanel;

    bool StartButton;
    bool SettingButton;
    bool MenuButton;
    bool BackButton;

    public static bool GamePause = false;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;

        StartButton = true;
        SettingButton = true;
        MenuButton = true;
        BackButton = true;


        MenuPanel = GameObject.Find("MainMenuPanel");
        SettingsPanel = GameObject.Find("SettingsPanel");
        GamePanel = GameObject.Find("GamePlayPanel");
        GameOverPanel = GameObject.Find("GameOverPanel");
        PausePanel = GameObject.Find("PausePanel");
    }

    // Update is called once per frame
    void Update()
    {
        m_PauseButton();
    }
    public void m_OnClickStart()
    {
        if (StartButton == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;

            MenuPanel.SetActive(false);
            GamePanel.SetActive(true);
            SettingsPanel.SetActive(false);
            GameOverPanel.SetActive(false);
            PausePanel.SetActive(false);
        }
    }
    public void m_OnClickSettings()
    {
        if (SettingButton == true)
        {
            MenuPanel.SetActive(false);
            SettingsPanel.SetActive(true);
        }

    }
    public void m_OnClickMenu()
    {
        if (MenuButton == true)
        {
            SettingsPanel.SetActive(false);
            MenuPanel.SetActive(true);
        }


    }
    public void m_PauseButton()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PausePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            GamePause = true;
        }
    }

    public void m_OnclickResumeButton()
    {
        PausePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        GamePause = false;
    }

    public void m_OnclickBackIcon()
    {
        if (BackButton == true)
        {
            SettingsPanel.SetActive(false);
            MenuPanel.SetActive(true);
        }

    }

    public void m_OnClickHomeButton()
    {
        MenuPanel.SetActive(true);
    }

    public void m_OnClickRestartButton()
    {
        SceneManager.LoadScene("Map_v2");
        GameOverPanel.SetActive(false);
    }

    public void m_OnClickQuitButton()
    {
        Application.Quit();
    }
}
