using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    public AudioSource door;
    public AudioSource key;

    private GameObject player;

    private bool playingDoor;
    private bool playingKey;

    private float keyVolume;
    private float doorVolume;

    void Start()
    {
        playingDoor = false;
        playingKey = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(player.transform.position, player.transform.up, 50f);
        if (hit.collider != null)
        {
            //Debug.Log(hit.transform.name);
            if (hit.transform.tag == "Door")
            {
                if(!playingDoor)
                {
                    door.volume = 1 / (hit.distance + 0.1f);
                    door.Play();
                    StartCoroutine(WaitOutSoundDoor());
                    playingDoor = true;
                }
            }

            if (hit.transform.tag == "Key")
            {
                if (!playingKey)
                {
                    key.volume = 1 / ((hit.distance + 0.1f) * 2) ;
                    key.Play();
                    StartCoroutine(WaitOutSoundKey());
                    playingKey = true;
                }
            }
        }
    }

    IEnumerator WaitOutSoundDoor()
    {
        yield return new WaitForSeconds(1.3f);
        playingDoor = false;
    }

    IEnumerator WaitOutSoundKey()
    {
        yield return new WaitForSeconds(1.3f);
        playingKey = false;
    }
}
