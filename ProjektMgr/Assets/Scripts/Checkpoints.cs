using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    private GameObject gameManager;

    private int checkpointReached;
    public GameObject player;

    [SerializeField] private GameObject nodeParent;
    Transform[] allChildren;
    List<GameObject> nodes = new List<GameObject>();

    public GameObject key;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");

        allChildren = nodeParent.GetComponentsInChildren<Transform>();

        foreach (Transform child in allChildren)
        {
            nodes.Add(child.gameObject);
        }

        if(PlayerPrefs.GetInt("checkpointReached", 1) != 1)
        {
            SpawnPlayerOnCheckpoint();
        }


        checkpointReached = PlayerPrefs.GetInt("checkpointReached", 1);

        Debug.Log(PlayerPrefs.GetInt("checkpointReached"));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            int locationId = GetComponent<CurrentLocation>().GetLocationId() +1;

            if(locationId > PlayerPrefs.GetInt("checkpointReached"))
            {
                PlayerPrefs.SetInt("checkpointReached", locationId);
                checkpointReached = PlayerPrefs.GetInt("checkpointReached");
            }

        Debug.Log(PlayerPrefs.GetInt("checkpointReached"));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            int thisLocation = GetComponent<CurrentLocation>().GetLocationId();
            checkpointReached = PlayerPrefs.GetInt("checkpointReached");

            player.transform.position = allChildren[checkpointReached].transform.position;

            thisLocation = GetComponent<CurrentLocation>().GetLocationId();

            if (checkpointReached != 6 && thisLocation == checkpointReached - 1)
            {
                Debug.Log(thisLocation + ", " + checkpointReached );
                key.SetActive(true);

                DealWithKeys(checkpointReached);
                
                gameManager.GetComponent<KeysManager>().UnsetKey(PlayerPrefs.GetInt("checkpointReached") - 1);
                gameManager.GetComponent<KeysManager>().UnsetDoor(PlayerPrefs.GetInt("checkpointReached") - 1);
            }

        }
    }

    private void SpawnPlayerOnCheckpoint()
    {
        checkpointReached = PlayerPrefs.GetInt("checkpointReached");
        player.transform.position = allChildren[checkpointReached].transform.position;

        DealWithKeys(checkpointReached);

    }

    private void DealWithKeys(int point)
    {
        point -= 2;

        for (int i = point; i >= 0; i--)
        {
            gameManager.GetComponent<KeysManager>().SetKey(i);
            gameManager.GetComponent<KeysManager>().SetDoor(i);

            if(i == GetComponent<CurrentLocation>().GetLocationId())
            {
                key.SetActive(false);
            }
        }

    }


}
