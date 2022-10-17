using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DirectionSoundPitch : MonoBehaviour
{
    public AudioSource hum;
    private float low = 0.75f;
    private float high = 1.25f;

    private float laserLength = 50f;
    private GameObject player;
    private float pitchValue;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //StartCoroutine(ChangePitch());
        pitchValue = 1f;
    }

    private IEnumerator ChangePitch()
    {
        yield return new WaitForSeconds(1.5f);

        hum.pitch = low;

        yield return new WaitForSeconds(1.5f);

        hum.pitch = high;
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
                        Debug.Log(hit.transform.name);

                    }
                    else if (hit.transform.tag == "Item")
                        Debug.Log(hit.transform.name);
                }

            }

            hum.pitch = pitchValue;
        }
                

    }
}
