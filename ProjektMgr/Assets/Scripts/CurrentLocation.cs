using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentLocation : MonoBehaviour
{
    public Text locationText;
    private string location;
    public int locationId;

    private GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");

        switch (locationId)
        {
            case 0:
                location = "Room 1";
                break;
            case 1:
                location = "Room 2";
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

        }
        if (col.transform.tag == "Ghost")
        {
            gameManager.gameObject.GetComponent<GhostCounting>().AddGhost(locationId);
              
        }

    }

}
