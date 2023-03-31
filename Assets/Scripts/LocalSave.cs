using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocalSave : MonoBehaviour
{
    public bool[] finished = new bool[12];
    public bool[] secrets = new bool[12];
    public bool gunLock = false;
    public bool jumpLock = false;
    public bool sprintLock = false;

    void Start()
    {
        LoadPlayer();
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            LoadSecrets();
        }
        
    }

    public void LevelComplete(bool secret)
    {
        finished[SceneManager.GetActiveScene().buildIndex - 1] = true;
        secrets[SceneManager.GetActiveScene().buildIndex - 1] = secret;

        SavePlayer();

        LoadSecrets();
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

    public void ResetPlayer()
    {
        SaveSystem.DeletePlayer();
        SceneManager.LoadScene(0);
    }

    void LoadSecrets()
    {
       int value = 0;
 
       for(int i = 0; i < secrets.Length; i++) 
       {
            if(secrets[i] == true) value++;
       }
        if (value >= 4 && gunLock == false)
        {

        }
        else if (value >= 8 && jumpLock == false)
        {

        }
        else if (value >= 12 && sprintLock == false)
        {
            
        }
    }
}
