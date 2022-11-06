using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOnScreen : MonoBehaviour
{
    public Text direction;
    public Text location;
    public Text item;

    private string itemString;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        ReadLocation();
        player = GameObject.FindGameObjectWithTag("Player");
    }

// Update is called once per frame
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
            UAP_AccessibilityManager.Say(location.text.ToString());
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            RaycastHit2D hit;
            hit = Physics2D.Raycast(player.transform.position, player.transform.up, 50f);
            if (hit.collider != null)
            {
                //Debug.Log(hit.transform.name);
                if (hit.transform.tag == "Wall")
                {
                    string dist;

                    if (hit.distance < 1)
                    {
                        dist = ", very near";
                    }
                    else if(hit.distance < 2)
                    {
                        dist = ", near";
                    }
                    else if(hit.distance > 5)
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

                    //Debug.Log(hit.distance);
                    itemString = hit.transform.tag + dist;
                }
                else
                {
                    itemString = hit.transform.tag;
                }

                item.text = itemString;
                StartCoroutine(ItemTextFade());
                UAP_AccessibilityManager.Say(item.text.ToString());
                //Debug.Log(itemString);
            }
        }
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
