using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public bool[] newfinished;
    public bool[] newsecrets;
    public bool gunLock = false;
    public bool jumpLock = false;
    public bool sprintLock = false;

    public PlayerData (LocalSave save)
    {
        newfinished = save.newfinished;
        newsecrets = save.newsecrets;
        gunLock = save.gunLock;
        jumpLock = save.jumpLock;
        sprintLock = save.sprintLock;
    }
}
