using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CurrentLocation : MonoBehaviour
{
    public Text locationText;
    public string location;

    private GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.tag == "Player")
        {
            Debug.Log(transform.name);
            locationText.text = location;
            gameManager.GetComponent<TextOnScreen>().ReadLocation();

        }


    }


}
