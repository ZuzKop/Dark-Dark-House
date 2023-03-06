using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentLocation : MonoBehaviour
{
    public Text locationText;
    public Text statusText;
    private string location;
    public int locationId;

    private GameObject gameManager;
    private int lvlId;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        lvlId = gameManager.GetComponent<PlayerStatus>().GetLevelId();


        switch (locationId)
        {
            case 0:
                location = "Room 1";
                break;
            case 1:
                location = "Room 2";
                break;
            case 2:
                location = "Room 3";
                break;
            default:
                location = "room";
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.tag == "Player")
        {
            locationText.text = location;
            gameManager.GetComponent<TextOnScreen>().ReadLocation();
            gameManager.GetComponent<PlayerStatus>().SetLocation(locationId);

            string tutorialText;

            switch (locationId)
            {
                case 0:
                    tutorialText = "Move the camera to find the knock sound. It means you're looking at a door. Approach it to enter the next room. ";
                    break;
                case 1:
                    tutorialText = "If you find the ding sound, that means you're looking at a key. Collect it so you can unlock closed doors.";
                    break;
                case 2:
                    tutorialText = "Press spacebar to shoot the ghost-catching gun. When you hear a heartbeat, you're very close to the ghost, be careful not to walk into it.";
                    break;
                default:
                    tutorialText = "";
                    break;
            }

            statusText.text = tutorialText;

        }
        if (col.transform.tag == "Ghost")
        {
            gameManager.gameObject.GetComponent<GhostCounting>().AddGhost(locationId);
              
        }

    }

}
