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
    public GameObject gun;
    public GameObject jump;
    public GameObject sprint;
    public GameObject screen;
    public GameObject player;
    public scoregame score;

    void Awake()
    {
        LoadPlayer();

        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (gunLock == true)
            {
                gun.SetActive(true);
            }
            if (jumpLock == true)
            {
                jump.SetActive(true);
            }
            if (sprintLock == true)
            {
                sprint.SetActive(true);
            }
            LoadSecrets();
        }
        
    }

    public void LevelComplete(bool secret)
    {
        finished[SceneManager.GetActiveScene().buildIndex - 1] = true;
        secrets[SceneManager.GetActiveScene().buildIndex - 1] = secret;

        SavePlayer();
    }
    public void PowerUpGet(int powerup)
    {
        if (powerup == 0)
        {
            gunLock = true;
        }
        else if (powerup == 1)
        {
            jumpLock = true;
        }
        else if (powerup == 2)
        {
            sprintLock = true;
        }
        else
        {
            Debug.LogError("Power up number is out of bounds");
        }

        screen.SetActive(true);
        Invoke("LoadMenu", 5);
    }

    public void LoadMenu()
    {
        SavePlayer();
        SceneManager.LoadScene(0);
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
        gunLock = data.gunLock;
        jumpLock = data.jumpLock;
        sprintLock = data.sprintLock;
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            player = GameObject.Find("Player");
            score = player.GetComponent<scoregame>();
            score.SaveStart();
        }
    }

    public void ResetPlayer()
    {
        SaveSystem.DeletePlayer();
        SceneManager.LoadScene(0);
    }

    public void LoadSecrets()
    {
       int value = 0;
 
       for(int i = 0; i < secrets.Length; i++) 
       {
            if(secrets[i] == true) value++;
       }
        if (value >= 4 && gunLock == false)
        {
            SceneManager.LoadScene(13);
        }
        else if (value >= 8 && jumpLock == false)
        {
            SceneManager.LoadScene(14);
        }
        else if (value >= 12 && sprintLock == false)
        {
            SceneManager.LoadScene(15);
        }
    }
}
