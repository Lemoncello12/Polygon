using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public bool[] finished;
    public bool[] secrets;
    public bool gunLock = false;
    public bool jumpLock = false;
    public bool sprintLock = false;

    public PlayerData (LocalSave save)
    {
        finished = save.finished;
        secrets = save.secrets;
        gunLock = save.gunLock;
        jumpLock = save.jumpLock;
        sprintLock = save.sprintLock;
    }
}
