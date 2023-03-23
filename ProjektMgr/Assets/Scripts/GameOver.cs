using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private GameObject player;
    
    public AudioSource gameOverSound;
    public GameObject allSounds;
    public GameObject mainCanvas;
    public GameObject gameOverCanvas;
    public GameObject textGameOver;

    public AudioSource winSound;
    public GameObject textTutorialOver;

    private GameObject gameManager;
    private int lvlId;


    private bool skippable;
    private bool dead;
    private bool tutorialWin;

    // Start is called before the first frame update
    void Start()
    {

        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        player = GameObject.FindGameObjectWithTag("Player");

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
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else if(tutorialWin)
            {
                Debug.Log("Restart");
                SceneManager.LoadScene(0);
            }
        }
    }

    public void GOver()
    {
        player.SetActive(false);

        allSounds.SetActive(false);
        gameOverSound.Play();

        mainCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);

        StartCoroutine(WaitOut());

    }

    public void TutorialOver()
    {
        player.SetActive(false);

        StartCoroutine(WinWaitOut());

    }
    IEnumerator WinWaitOut()
    {
        yield return new WaitForSeconds(.075f);
        mainCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        textTutorialOver.SetActive(true);

        if (lvlId == 1)
        {
            textTutorialOver.GetComponent<Text>().text = "Totorial completed. Press Enter to return to main menu.";
        }
        if(lvlId == 2)
        {
            textTutorialOver.GetComponent<Text>().text = "You win, the house is safe now. Press Enter to return to main menu.";
        }
        if (lvlId == 3)
        {
            textTutorialOver.GetComponent<Text>().text = "You win, you escaped the labirynth. Press Enter to return to main menu.";
        }

        allSounds.SetActive(false);
        winSound.Play();

        yield return new WaitForSeconds(.05f);

        if(lvlId == 1)
        {
            UAP_AccessibilityManager.Say("Totorial completed. Press Enter to return to main menu.");
        }
        if(lvlId == 2)
        {
            UAP_AccessibilityManager.Say("You win, the house is safe now. Press Enter to return to main menu.");
        }
        if (lvlId == 3)
        {
            UAP_AccessibilityManager.Say("You win, you escaped the labirynth. Press Enter to return to main menu.");
        }
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