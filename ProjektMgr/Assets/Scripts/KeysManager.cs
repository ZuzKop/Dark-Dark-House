using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysManager : MonoBehaviour
{
    public bool[] keys;
    public bool[] doors;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetKey(int id)
    {
        keys[id] = true;
    }

    public bool GetKey(int id)
    {
        return keys[id];
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
