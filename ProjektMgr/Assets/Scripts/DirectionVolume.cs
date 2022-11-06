using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DirectionVolume : MonoBehaviour
{
    public AudioSource hum;

    private float laserLength = 50f;
    private GameObject player;
    private float vol;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        vol = 0.5f;
    }

    void FixedUpdate()
    {
        RaycastHit2D[] hits;
        bool hitWall = false;

        hits = Physics2D.RaycastAll(player.transform.position, player.transform.up, laserLength);

        if (hits.Length > 0)
        {
            Array.Sort(hits, (RaycastHit2D x, RaycastHit2D y) => x.distance.CompareTo(y.distance));
        }

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit2D hit = hits[i];
            if (hit.collider != null)
            {
                if (!hitWall)
                {
                    if (hit.transform.tag == "Wall")
                    {
                        float v = ( 1f /( hit.distance + 0.01f) ) * 0.3f ;
                        vol = v;

                        hitWall = true;
                    }
                }

            }

            hum.volume = vol;
        }

    }
}
