using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{

    // Start is called before the first frame update

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
        SceneManager.LoadScene(3);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
