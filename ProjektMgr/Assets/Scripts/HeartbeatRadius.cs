using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartbeatRadius : MonoBehaviour
{
    public AudioSource heartbeat;

    // Start is called before the first frame update
    void Start()
    {
        heartbeat.volume = 0f;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.tag == "Player" )
        {
            heartbeat.volume = 1f;
        }
        else
        {
            heartbeat.volume = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        heartbeat.volume = 0f;
    }
}
