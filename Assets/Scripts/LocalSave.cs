using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocalSave : MonoBehaviour
{
    public bool[] finished = new bool[12];
    public bool[] secrets = new bool[12];

    void Start()
    {
        LoadPlayer();
    }

    public void LevelComplete(bool secret)
    {
        finished[SceneManager.GetActiveScene().buildIndex - 1] = true;
        secrets[SceneManager.GetActiveScene().buildIndex - 1] = secret;

        SavePlayer();
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        finished = data.finished;
        secrets = data.secrets;
    }
}
