using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOnScreen : MonoBehaviour
{
    public Text direction;
    public Text location;

    // Start is called before the first frame update
    void Start()
    {
        ReadLocation();
    }

// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(DirectionTextFade());
            UAP_AccessibilityManager.Say(direction.text.ToString());
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            UAP_AccessibilityManager.Say(location.text.ToString());
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



    public void ReadLocation()
    {
        UAP_AccessibilityManager.Say(location.text.ToString());

    }
}
