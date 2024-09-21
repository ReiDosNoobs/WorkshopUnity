using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Status
{
    public int health;
    public int armour;
    public int magicResist;

    public void Init()
    {
        health = 100;
        armour = 20;
        magicResist = 10;
    }
}
