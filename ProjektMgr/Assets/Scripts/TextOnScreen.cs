using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOnScreen : MonoBehaviour
{
    public Text direction;
    public Text location;
    public Text item;
    public Text ghostCounter;
    public Text pickUpKey;

    private string itemString;

    private GameObject player;
    private GameObject gameManager;

    private int lvlId;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindWithTag("GameManager");

        lvlId = gameManager.GetComponent<PlayerStatus>().GetLevelId();

        if(lvlId == 2)
        {
            ghostCounter.text = "Find a ghost-hunting gun to kill a ghost locked up in the basement cell.";
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(DirectionTextFade());
            UAP_AccessibilityManager.Say(direction.text.ToString());
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(DirectionTextFade());
            UAP_AccessibilityManager.Say(direction.text.ToString());
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(DirectionTextFade());
            UAP_AccessibilityManager.Say(direction.text.ToString());
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(DirectionTextFade());
            UAP_AccessibilityManager.Say(direction.text.ToString());
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(DirectionTextFade());
            UAP_AccessibilityManager.Say(direction.text.ToString());
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            UAP_AccessibilityManager.Say(location.text.ToString() + ", " + ghostCounter.text.ToString());
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            RaycastHit2D hit;
            hit = Physics2D.Raycast(player.transform.position, player.transform.up, 50f);
            if (hit.collider != null)
            {
                switch(hit.transform.tag)
                {
                    case "Wall":

                        string dist;

                        if (hit.distance < 1)
                        {
                            dist = ", very near";
                        }
                        else if (hit.distance < 2)
                        {
                            dist = ", near";
                        }
                        else if (hit.distance > 5)
                        {
                            dist = ", far";

                        }
                        else if (hit.distance > 10)
                        {
                            dist = ", very far";

                        }
                        else
                        {
                            dist = "";
                        }

                        itemString = hit.transform.tag + dist;
                        break;

                    case "Key":
                        itemString = "Key to" + gameManager.GetComponent<KeysManager>().GetKeyName(hit.transform.gameObject.GetComponent<PickingUpKeys>().GetKeyID());
                        break;
                    case "Door":
                        itemString = "Door to" + gameManager.GetComponent<KeysManager>().GetDoorName(hit.transform.gameObject.GetComponent<OpeningDoors>().GetDoorID());

                        if(!gameManager.GetComponent<KeysManager>().GetKey(hit.transform.gameObject.GetComponent<OpeningDoors>().GetDoorID()))
                        {
                            itemString += ", locked";
                        }
                        break;
                    case "Ghost":
                        itemString = hit.transform.tag + ", " + hit.transform.gameObject.GetComponent<GhostCollision>().GetHp() + " Hit Points";
                        break;
                    case "Gun":
                        itemString = "Ghost-hunting " + hit.transform.tag;
                        break;

                    default:
                        itemString = hit.transform.tag;
                        break;

                }

                item.text = itemString;
                StartCoroutine(ItemTextFade());
                UAP_AccessibilityManager.Say(item.text.ToString());
            }
        }
    }

    public void UpdateQuestText()
    {
        ghostCounter.text = "Kill a ghost locked up in the basement cell with a ghost-hunting gun.";
        UAP_AccessibilityManager.Say(ghostCounter.text);
    }

    public void PickUpKeyText(int keyId)
    {
        pickUpKey.text = "Key to" + gameManager.GetComponent<KeysManager>().GetKeyName(keyId);
        UAP_AccessibilityManager.Say("Key to" + gameManager.GetComponent<KeysManager>().GetKeyName(keyId));
        StartCoroutine(KeyTextFade());

    }
    IEnumerator KeyTextFade()
    {
        Color col = direction.color;
        col.a = 1.0f;
        pickUpKey.color = col;

        yield return new WaitForSeconds(0.5f);

        while (col.a >= 0.0f)
        {
            col.a -= 0.004f;
            pickUpKey.color = col;
            yield return null;
        }

        col.a = 0.0f;
        pickUpKey.color = col;
    }
    IEnumerator DirectionTextFade()
    {
        Color col = direction.color;
        col.a = 1.0f;
        direction.color = col;

        yield return new WaitForSeconds(0.5f);

        while (col.a >= 0.0f)
        {
            col.a -= 0.004f;
            direction.color = col;
            yield return null;
        }

        col.a = 0.0f;
        direction.color = col;
    }

    IEnumerator ItemTextFade()
    {
        Color col = direction.color;
        col.a = 1.0f;
        item.color = col;

        yield return new WaitForSeconds(0.5f);

        while (col.a >= 0.0f)
        {
            col.a -= 0.004f;
            item.color = col;
            yield return null;
        }

        col.a = 0.0f;
        item.color = col;
    }

    public void ReadLocation()
    {
        UAP_AccessibilityManager.Say(location.text.ToString());
    }
}
