using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalSave : MonoBehaviour
{
    public bool[] finished = new bool[12];
    public bool[] secrets = new bool[12];

    public void SavePlayer()
    {
        SaveSystem.SavePlayer();
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        finished = data.finished;
        secrets = data.secrets;
    }
}
