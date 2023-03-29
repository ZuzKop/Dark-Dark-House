using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartbeatRadius : MonoBehaviour
{
    public AudioSource heartbeat;
    private bool silent;

    // Start is called before the first frame update
    void Start()
    {
        silent = false;
        heartbeat.volume = 0f;
    }

    public void SetSilent(bool flag)
    {
        silent = flag;
    }
    public bool GetSilent()
    {
        return silent;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.tag == "Player" && !silent)
        {
            heartbeat.volume = 1f;
            Debug.Log("unsilencing");
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            heartbeat.volume = 0f;
            Debug.Log("silencing");
        }
    }
}
