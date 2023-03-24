using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public bool[] finished;
    public bool[] secrets;
    public bool sprintLock = false;
    public bool gunLock = false;

    public PlayerData (LocalSave save)
    {
        finished = save.finished;
        secrets = save.secrets;
    }
}
