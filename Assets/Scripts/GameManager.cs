using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    private Vector3 _spawnPos;
    //private Quaternion _spawnRot;
    private HealthScript _health;
    private scoregame _movement;

    void Start()
    {
        _spawnPos = Player.transform.position;
        //_spawnRot = Player.transform.rotation;
        _health = Player.GetComponent<HealthScript>();
        _movement = Player.GetComponent<scoregame>();
    }

    public void OnDeath()
    {
        Invoke("Reset", 3); //Respawn in 3 seconds.
    }

    public void Reset()
    {
        _health.Reset();
        Player.transform.position = _spawnPos;
        //Player.transform.rotation = _spawnRot;
    }

}
