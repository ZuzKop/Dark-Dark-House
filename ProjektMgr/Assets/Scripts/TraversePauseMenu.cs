using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TraversePauseMenu : MonoBehaviour
{
    public GameObject pauseMenuFirstButton;
    public GameObject settingsFirstButton;

    public void PauseMenuEvent()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(pauseMenuFirstButton);
    }
    public void SettingsEvent()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(settingsFirstButton);
    }
    public void ResetEvent()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }


}
