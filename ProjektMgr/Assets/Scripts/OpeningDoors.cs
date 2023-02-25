using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningDoors : MonoBehaviour
{
    public AudioSource locked;
    public AudioSource unlocking;
    public AudioSource opening;

    public int doorID;

    private GameObject GameManager;

    public bool isOpening;

    void Start()
    {
        GameManager = GameObject.FindWithTag("GameManager");
        isOpening = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Player")
        {
            if (GameManager.GetComponent<KeysManager>().GetDoor(doorID))
            {
                opening.Play();
                Debug.Log("opening");

                StartCoroutine(DisableCollider());

            }
            else if (GameManager.GetComponent<KeysManager>().GetKey(doorID))
            {
                Debug.Log("unlocking");
                StartCoroutine(Unlocking());
                GameManager.GetComponent<KeysManager>().SetDoor(doorID);
            }
            else
            {
                locked.Play();
            }
        }
    }

    public int GetDoorID()
    {
        return doorID;
    }

    IEnumerator Unlocking()
    {
        unlocking.Play();
        yield return new WaitForSeconds(0.5f);
        opening.Play();
        StartCoroutine(DisableCollider());
    }

    IEnumerator DisableCollider()
    {
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(2.0f);
        GetComponent<Collider2D>().enabled = true;

    }

}

