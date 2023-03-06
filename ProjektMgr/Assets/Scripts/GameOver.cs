using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public AudioSource gameOverSound;
    public GameObject allSounds;
    public GameObject mainCanvas;
    public GameObject gameOverCanvas;
    public GameObject textGameOver;

    public AudioSource winSound;
    public GameObject textTutorialOver;

    private bool skippable;
    private bool dead;
    private bool tutorialWin;

    // Start is called before the first frame update
    void Start()
    {
        skippable = false;
        dead = false;
        tutorialWin = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && skippable)
        {
            if(dead)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
            else if(tutorialWin)
            {
                Debug.Log("Restart");
                Application.LoadLevel(0);
            }
        }
    }

    public void GOver()
    {
        allSounds.SetActive(false);
        gameOverSound.Play();

        mainCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);

        StartCoroutine(WaitOut());

    }

    public void TutorialOver()
    {
        StartCoroutine(WinWaitOut());

    }
    IEnumerator WinWaitOut()
    {
        yield return new WaitForSeconds(.075f);
        mainCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        textTutorialOver.SetActive(true);
        allSounds.SetActive(false);
        winSound.Play();

        yield return new WaitForSeconds(.05f);

        UAP_AccessibilityManager.Say("Totorial completed. Press Enter to return to main menu.");
        skippable = true;
        tutorialWin = true;
    }
    IEnumerator WaitOut()
    {
        yield return new WaitForSeconds(2f);
        textGameOver.SetActive(true);
        skippable = true;
        dead = true;
        UAP_AccessibilityManager.Say("Game Over. Press Enter to restart.");


    }
}