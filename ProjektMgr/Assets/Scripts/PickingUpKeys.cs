using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingUpKeys : MonoBehaviour
{

    public AudioSource collectionSound;

    public int keyID;
    private GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
    }

    public int GetKeyID()
    {
        return keyID;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        gameManager.GetComponent<KeysManager>().SetKey(keyID); 
        collectionSound.Play();
        gameManager.GetComponent<TextOnScreen>().PickUpKeyText(keyID);
        gameObject.SetActive(false);
    }
}
