using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    private int room;

    private int levelId;

    private int locationsNumber;


    void Start()
    {
        levelId = SceneManager.GetActiveScene().buildIndex;

        GameObject[] getCount = GameObject.FindGameObjectsWithTag("Location");
        locationsNumber = getCount.Length;

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
