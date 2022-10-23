using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingUpKeys : MonoBehaviour
{

    public AudioSource collectionSound;

    public int keyID;
    private GameObject GameManager;

    void Start()
    {
        GameManager = GameObject.FindWithTag("GameManager");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GameManager.GetComponent<KeysManager>().SetKey(keyID); 
        collectionSound.Play();
        gameObject.SetActive(false);
    }
}
