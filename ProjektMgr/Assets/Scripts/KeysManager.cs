using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysManager : MonoBehaviour
{
    public bool[] keys;
    public bool[] doors;

    private GameObject gameManager;
    private int lvlId;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        lvlId = gameManager.GetComponent<PlayerStatus>().GetLevelId();
    }

    public void SetKey(int id)
    {
        keys[id] = true;
    }

    public bool GetKey(int id)
    {
        return keys[id];
    }

    public string GetKeyName(int id)
    {
        string txt = "";

        if(lvlId == 1)
        {
            switch (id)
            {
                case 0:
                    txt = " room two";
                    break;

                case 1:
                    txt = " last room";
                    break;

                default:
                    txt = "";
                    Debug.Log("switch default case: something went wrong");
                    break;

            }
        }

        if (lvlId == 2)
        {
            switch (id)
            {
                case 0:
                    txt = " hall";
                    break;
                case 1:
                    txt = " bathroom";
                    break;
                case 5:
                    txt = " attic";
                    break;
                case 6:
                    txt = " basement";
                    break;
                case 7:
                    txt = " ghost cell";
                    break;

                default:
                    txt = "";
                    Debug.Log("switch default case: something went wrong");
                    break;
            }
        }

        return txt;
    }
    public string GetDoorName(int id)
    {
        int roomID = gameObject.GetComponent<PlayerStatus>().GetLocation();

        string txt = "";

        //if room is changed, so is the name of the door. depending on room player is in there are two variants of the name of the door

        if(lvlId == 1)
        {
            switch (id)
            {
                case 0:
                    if(roomID == 0)
                    {
                        txt = " room two";
                    }
                    else if(roomID == 1)
                    {
                        txt = " room one";
                    }
                    break;

                case 1:
                    if (roomID == 1)
                    {
                        txt = " room three";
                    }
                    else if (roomID == 2)
                    {
                        txt = " room two";
                    }
                    break;

                default:
                    txt = "";
                    Debug.Log("switch default case: something went wrong");
                    break;

            }
        }

        if(lvlId == 2)
        {
            switch (id)
            {
                case 0:
                    if (roomID == 0)
                    {
                        txt = " hall";
                    }
                    else
                    {
                        txt = " anteroom";
                    }
                    break;

                case 1:
                    if (roomID == 2)
                    {
                        txt = " hall";
                    }
                    else
                    {
                        txt = " bathroom";
                    }
                    break;

                case 2:
                    if (roomID == 3)
                    {
                        txt = " hall";
                    }
                    else
                    {
                        txt = " livingroom";
                    }
                    break;

                case 3:
                    if (roomID == 4)
                    {
                        txt = " hall";
                    }
                    else
                    {
                        txt = " bedroom";
                    }
                    break;

                case 4:
                    if (roomID == 5)
                    {
                        txt = " hall";
                    }
                    else
                    {
                        txt = " kitchen";
                    }
                    break;

                case 5:
                    if (roomID == 6)
                    {
                        txt = " hall";
                    }
                    else
                    {
                        txt = " attic";
                    }
                    break;

                case 6:
                    if (roomID == 7)
                    {
                        txt = " kitchen";
                    }
                    else
                    {
                        txt = " basement";
                    }
                    break;

                case 7:
                    if (roomID == 8)
                    {
                        txt = " basement";
                    }
                    else
                    {
                        txt = " ghost cell";
                    }
                    break;

                default:
                    txt = "";
                    Debug.Log("switch default case: something went wrong");
                    break;

            }
        }

        return txt;

    }

    public bool GetDoor(int id)
    {
        return doors[id];
    }

    public void SetDoor(int id)
    {
        doors[id] = true;
    }

}
