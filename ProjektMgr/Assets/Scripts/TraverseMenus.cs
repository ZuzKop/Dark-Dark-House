using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TraverseMenus : MonoBehaviour
{
    public GameObject mainMenuFirstButton;
    public GameObject settingsFirstButton;
    public GameObject playFirstButton;
    public GameObject tutorialFirstButton;
    public GameObject easyFirstButton;
    public GameObject normalFirstButton;
    public GameObject normalSecondFirstButton;
    public GameObject creditsFirstButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void MainMenuEvent()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(mainMenuFirstButton);
    }

    public void SettingsEvent()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(settingsFirstButton);
    }
    public void PlayEvent()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(playFirstButton);
    }
    public void CreditsEvent()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(creditsFirstButton);
    }
    public void TutorialEvent()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(tutorialFirstButton);
    }
    public void EasyEvent()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(easyFirstButton);
    }
    public void NormalEvent()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(normalFirstButton);
    }
    public void NormalSecondEvent()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(normalSecondFirstButton);
    }
    /*
    public void xEvent()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(xFirstButton);
    }
    */
    void Update()
    {
        
    }
}
