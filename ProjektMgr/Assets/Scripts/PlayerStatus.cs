using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private int room;

    // Start is called before the first frame update
    public void SetLocation(int id)
    {
        room = id;
    }

    public int GetLocation()
    {
        return room;
    }
}
