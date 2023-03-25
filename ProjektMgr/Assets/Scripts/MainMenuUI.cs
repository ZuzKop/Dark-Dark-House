using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuUI : MonoBehaviour
{
    public GameObject sliderMouse;
    public GameObject sliderKeyboard;

    public TMP_Dropdown dropdown;
    public Slider keyboardSliderValue;
    public Slider mouseSliderValue;

    public TMP_Text tutorialInfo;

    public GameObject normalPanel;
    public GameObject secondNormalPanel;

    void Start()
    {
        int val;
        if (PlayerPrefs.GetInt("mouseInput", 1) == 0) val = 1;
        else val = 0;

        dropdown.value = val;

        keyboardSliderValue.value = PlayerPrefs.GetFloat("keyboardSensitivity", 0.55f);
        mouseSliderValue.value = PlayerPrefs.GetFloat("mouseSensitivity", 3f);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayTutorial()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayEasy()
    {
        SceneManager.LoadScene(2);
    }
    public void PlayNormal()
    {
        if(PlayerPrefs.GetInt("checkpointReached", 1) != 1)
        {
            normalPanel.SetActive(false);
            secondNormalPanel.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(3);

        }
    }

    public void PlayNormalFromCheckpoint()
    {
        SceneManager.LoadScene(3);
    }
    public void PlayNormalWiped()
    {
        PlayerPrefs.SetInt("checkpointReached", 1);
        SceneManager.LoadScene(3);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void DropDownInputMethod(int value)
    {
        if(value == 0)
        {
            sliderKeyboard.SetActive(false);
            sliderMouse.SetActive(true);

            PlayerPrefs.SetInt("mouseInput", 1);
            Debug.Log(PlayerPrefs.GetInt("mouseInput"));
        }
        if(value == 1)
        {
            sliderKeyboard.SetActive(true);
            sliderMouse.SetActive(false);
            PlayerPrefs.SetInt("mouseInput", 0);
            Debug.Log(PlayerPrefs.GetInt("mouseInput"));

        }
    }

    public void ChangeTutorialText()
    {
        string txt;

        if (PlayerPrefs.GetInt("mouseInput") == 1)
        {
            txt = "Change direction you're looking at by moving your mouse left and right. " +
                "Walk Forward with Left Mouse Button and walk bacwards with Right Mouse Button." +
                " You can change controls to keyboard-only in settings.";
        }
        else
        {
            txt = "Change direction you're looking at by pressing Left and Right Arrows. " +
                     "Walk Forward with Arrow Up and walk backwards with Arrow Down." +
                     " You can swap controls to mouse in settings.";
        }

        tutorialInfo.text = txt;

    }

    public void SliderCameraMouse()
    {
        PlayerPrefs.SetFloat("mouseSensitivity", mouseSliderValue.value);
    }
    public void SliderCameraKeyboard()
    {
        PlayerPrefs.SetFloat("keyboardSensitivity", keyboardSliderValue.value);
    }
}
