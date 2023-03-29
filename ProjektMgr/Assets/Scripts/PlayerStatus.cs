using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    private int room;

    private int levelId;

    private int locationsNumber;

    private bool hasGun;

    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public GameObject mainCanvas;
    public GameObject AllSounds;


    private bool paused;

    void Awake()
    {
        UAP_AccessibilityManager.BlockInput(true);
        levelId = SceneManager.GetActiveScene().buildIndex;

        GameObject[] getCount = GameObject.FindGameObjectsWithTag("Location");
        locationsNumber = getCount.Length;

        paused = false;

        if(levelId == 2)
        {
            hasGun = false;
        }
        else
        {
            hasGun = true;
        }

    }
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if(paused && settingsMenu.activeSelf )
            {
                pauseMenu.SetActive(true);
                settingsMenu.SetActive(false);
            }
            else if (paused)
            {
                UAP_AccessibilityManager.BlockInput(true);

                paused = false;

                AllSounds.SetActive(true);
                mainCanvas.SetActive(true);
                pauseMenu.SetActive(false);

            }
            else
            {
                UAP_AccessibilityManager.BlockInput(false);

                paused = true;


                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                AllSounds.SetActive(false);
                mainCanvas.SetActive(false);
                pauseMenu.SetActive(true);
            }

            
        }
    }

    public void Unpause()
    {
        UAP_AccessibilityManager.BlockInput(true);

        paused = false;

        AllSounds.SetActive(true);
        mainCanvas.SetActive(true);
        pauseMenu.SetActive(false);


        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public bool IsPaused()
    {
        return paused;
    }

    public bool DoHasGun()
    {
        return hasGun;
    }

    public void GunGotten()
    {
        hasGun = true;
    }

    public int GetLocationNumber()
    {
        return locationsNumber;
    }

    public int GetLevelId()
    {
        return levelId;
    }

    // Start is called before the first frame update
    public void SetLocation(int id)
    {
        room = id;
    }

    public int GetLocation()
    {
        return room;
    }
}
