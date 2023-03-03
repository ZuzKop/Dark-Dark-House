using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysManager : MonoBehaviour
{
    public bool[] keys;
    public bool[] doors;

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
        return txt;
    }
    public string GetDoorName(int id)
    {
        int roomID = gameObject.GetComponent<PlayerStatus>().GetLocation();

        string txt = "";

        //if room is changed, so is the name of the door. depending on room player is in there are two variants of the name of the door
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
                txt = " last room";
                break;

            default:
                txt = "";
                Debug.Log("switch default case: something went wrong");
                break;

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
