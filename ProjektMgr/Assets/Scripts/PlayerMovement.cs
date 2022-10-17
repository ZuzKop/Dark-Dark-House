using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    private float movementSpeed;
    public AudioSource click;

    public Text direction;

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 8f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("right"))
        {
            transform.eulerAngles += new Vector3(0f, 0f, -45f);
            click.Play();
            FixAngles();
            UpdateText();
        }

        if (Input.GetKeyDown("left"))
        {
            transform.eulerAngles += new Vector3(0f, 0f, 45f);
            click.Play();
            FixAngles();
            UpdateText();
        }

        if(Input.GetKey("up"))
        {
            GetComponent<Rigidbody2D>().MovePosition(transform.position + movementSpeed * Time.deltaTime * transform.up);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            UAP_AccessibilityManager.Say(direction.text.ToString());
        } 
    }

    
    private void FixAngles()
    {
        float ang = transform.eulerAngles.z;
        if (ang > 88f && ang < 92f)
            ang = 90f;

        if (ang > -2f && ang < 2f )
            ang = 0f;

        if (ang > 43 && ang < 47f)
            ang = 45f;


        transform.eulerAngles = new Vector3(0, 0, ang);

    }
    

    private void UpdateText()
    {

        float angle = transform.eulerAngles.z;
        float deg = angle;

        //Debug.Log(deg);

        if(Mathf.Approximately(deg, 0))
        {
            direction.text = "North";
        }
        else if (Mathf.Approximately(deg, 45))
        {
            direction.text = "North West";
        }
        else if (Mathf.Approximately(deg, 90))
        {
            direction.text = "West";
        }
        else if (Mathf.Approximately(deg, 135))
        {
            direction.text = "South West";
        }
        else if (Mathf.Approximately(deg, 180))
        {
            direction.text = "South";
        }
        else if (Mathf.Approximately(deg, 225))
        {
            direction.text = "South East";
        }
        else if (Mathf.Approximately(deg, 270))
        {
            direction.text = "East";
        }
        else if (Mathf.Approximately(deg, 315))
        {
            direction.text = "North East";
        }
        else
        {
            Debug.Log("flop");
        }

    }

}
