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


    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
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

        UpdateGhostCounter();
    }
    public int GetGhosts()
    {
        return ghostNumber;
    }
    public void UpdateGhostCounter()
    {
        ghostCounting.text = "Ghosts in this room: " + ghostInRooms[gameManager.GetComponent<PlayerStatus>().GetLocation()] + ", Total Ghosts: " + ghostNumber;
    }
}
