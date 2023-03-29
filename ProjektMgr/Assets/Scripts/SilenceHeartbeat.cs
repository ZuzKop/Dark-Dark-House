using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilenceHeartbeat : MonoBehaviour
{
    public int ghostLocation;
    private GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.GetComponent<PlayerStatus>().GetLocation() == ghostLocation && GetComponent<HeartbeatRadius>().GetSilent())
        {
            GetComponent<HeartbeatRadius>().SetSilent(false);
        }

        if(gameManager.GetComponent<PlayerStatus>().GetLocation() != ghostLocation && !GetComponent<HeartbeatRadius>().GetSilent())
        {
            GetComponent<HeartbeatRadius>().SetSilent(true);
        }
    }
}
