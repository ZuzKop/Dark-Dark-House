using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostCounting : MonoBehaviour
{
    public Text ghostCounting;

    private int ghostNumber;

    private int[] ghostInRooms;

    private GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        ghostNumber = 0;
        ghostInRooms = new int[2] { 0, 0};
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
