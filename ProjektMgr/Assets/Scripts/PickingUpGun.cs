using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingUpGun : MonoBehaviour
{
    public AudioSource collectionSound;
    private GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        gameManager.GetComponent <PlayerStatus>().GunGotten();
        gameManager.GetComponent<TextOnScreen>().UpdateQuestText();
        collectionSound.Play();
        gameObject.SetActive(false);
    }
}
