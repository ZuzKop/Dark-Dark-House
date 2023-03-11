using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostCounting : MonoBehaviour
{
    public Text ghostCounting;

    private int ghostNumber;

    private int locationsNumber;
    private List<int> ghostInRooms = new List<int>();

    private GameObject gameManager;
    private int lvlId;


    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        lvlId = gameManager.GetComponent<PlayerStatus>().GetLevelId();

        ghostNumber = 0;

        locationsNumber = gameManager.GetComponent<PlayerStatus>().GetLocationNumber();

        for(int i=0; i<locationsNumber; i++ )
        {
            ghostInRooms.Add(0);
        }
    }
    public void AddGhost(int roomId)
    {
        ghostNumber++;
        ghostInRooms[roomId]++;
        UpdateGhostCounter();
    }
    public void SubGhost()
    {
        ghostNumber--;
        ghostInRooms[gameManager.GetComponent<PlayerStatus>().GetLocation()]--;

        if(ghostNumber == 0)
        {
            Debug.Log("Tutorial over.");
            gameManager.GetComponent<GameOver>().TutorialOver();
        }

        UpdateGhostCounter();
    }
    public int GetGhosts()
    {
        return ghostNumber;
    }
    public void UpdateGhostCounter()
    {
        if(lvlId != 1 && lvlId != 2)
        {
            ghostCounting.text = "Ghosts in this room: " + ghostInRooms[gameManager.GetComponent<PlayerStatus>().GetLocation()] + ", Total Ghosts: " + ghostNumber;
        }
    }
}
