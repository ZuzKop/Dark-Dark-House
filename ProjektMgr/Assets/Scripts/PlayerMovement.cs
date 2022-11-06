using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    private float movementSpeed;
    public float keySensitivity;
    public float mouseSensitivity;
    public bool mouseControls;

    public AudioSource click;
    public AudioSource footsteps;

    public Text direction;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        movementSpeed = 2f;
        keySensitivity = 0.55f;
        mouseSensitivity = 3f;
        mouseControls = true;
    }

    // Update is called once per frame
    void Update()
    {
        //keyboard
        if (Input.GetKey("right"))
        {
            transform.eulerAngles += new Vector3(0f, 0f, -1f * keySensitivity);
            UpdateText();
        }

        if (Input.GetKey("left"))
        {
            transform.eulerAngles += new Vector3(0f, 0f, 1f * keySensitivity);
            UpdateText();
        }

        //mouse
        if(mouseControls)
        {
            transform.Rotate(0, 0, -Input.GetAxis("Mouse X") * mouseSensitivity);
            UpdateText();
        }

        if (Input.GetKey("up") || Input.GetMouseButton(0))
        {
            footsteps.volume = 0.6f;
            GetComponent<Rigidbody2D>().MovePosition(transform.position + movementSpeed * Time.fixedDeltaTime * transform.up);
        }
        else if (Input.GetKey("down") || Input.GetMouseButton(1))
        {
            footsteps.volume = 0.6f;
            GetComponent<Rigidbody2D>().MovePosition(transform.position + movementSpeed * Time.fixedDeltaTime * (-1)*transform.up);
        }
        else
        {
            footsteps.volume = 0f;
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            UpdateText();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0f, 0f, 90f);
            UpdateText();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.eulerAngles = new Vector3(0f, 0f, 180f);
            UpdateText();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0f, 0f, 270f);
            UpdateText();
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
        if (deg >= 337 || deg < 22)
        {
            if (direction.text != "North")
            {
                click.pitch = 1f;
                click.Play();
            }
            direction.text = "North";
        }
        else if (deg >= 22 && deg < 67)
        {
            direction.text = "North West";
        }
        else if (deg >= 67 && deg < 112)
        {
            if (direction.text != "West")
            {
                click.pitch = 1.3f;
                click.Play();
            }
            direction.text = "West";
        }
        else if (deg >= 112 && deg < 157)
        {
            direction.text = "South West";
        }
        else if (deg >= 157 && deg < 202)
        {
            if (direction.text != "South")
            {
                click.pitch = 1.2f;
                click.Play();
            }
            direction.text = "South";
        }
        else if (deg >= 202 && deg < 247)
        {
            direction.text = "South East";
        }
        else if (deg >= 247 && deg < 292)
        {
            if (direction.text != "East")
            {
                click.pitch = 1.1f;
                click.Play();
            }
            direction.text = "East";
        }
        else if (deg >= 292 && deg < 337)
        {
            direction.text = "North East";
        }
        else
        {
            Debug.Log("flop");
        }


        /*
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
        */

    }

}
