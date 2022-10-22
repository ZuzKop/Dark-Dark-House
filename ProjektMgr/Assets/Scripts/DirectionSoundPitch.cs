using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DirectionSoundPitch : MonoBehaviour
{
    public AudioSource hum;

    private float laserLength = 50f;
    private GameObject player;
    private float pitchValue;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pitchValue = 1f;
    }


    void FixedUpdate()
    {
        RaycastHit2D[] hits;
        bool hitWall = false;

        hits = Physics2D.RaycastAll(player.transform.position, player.transform.up, laserLength);

        if(hits.Length > 0)
        {
            Array.Sort(hits, (RaycastHit2D x, RaycastHit2D y) => x.distance.CompareTo(y.distance));
        }

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit2D hit = hits[i];
            if (hit.collider != null)
            {
                if(!hitWall)
                {
                    if (hit.transform.tag == "Wall")
                    {
                        pitchValue = hit.distance / 12f + 0.1f;
                        hitWall = true;
                        //Debug.Log(hit.transform.name);

                    }
                }

            }

            hum.pitch = pitchValue;
        }
                

    }
}
