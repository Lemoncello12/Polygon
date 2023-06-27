using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    public GameObject wave2;
    public GameObject wave3;
    public GameObject wave4;
    public GameObject wave5;
    public GameObject wave6;
    public GameObject wave7;
    public GameObject wave8;
    public GameObject wave9;
    public GameObject leafo;
    public int lock2 = 7;
    public int lock3 = 17;
    public int lock4 = 29;
    public int lock5 = 42;
    public int lock6 = 59;
    public int lock7 = 79;
    public int lock8 = 99;
    public int lock9 = 139;
    public int bossLock = 149;
    public int tpTrue = 0;
    private scoregame scoreGet;
    private GameObject player;
    private Vector3 place;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        scoreGet = player.GetComponent<scoregame>();
        place = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       score = scoreGet.score;
        if (score == lock2 && tpTrue != 2)
        {
            wave2.SetActive(true);
            player.transform.position = place;
            tpTrue = 2;
        }
        if (score == lock3 && tpTrue != 3)
        {
            wave3.SetActive(true);
            player.transform.position = place;
            tpTrue = 3;
        }
        if (score == lock4 && tpTrue != 4)
        {
            wave4.SetActive(true);
            player.transform.position = place;
            tpTrue = 4;
        }
        if (score == lock5 && tpTrue != 5)
        {
            wave5.SetActive(true);
            player.transform.position = place;
            tpTrue = 5;
        }
        if (score == lock6 && tpTrue != 6)
        {
            wave6.SetActive(true);
            player.transform.position = place;
            tpTrue = 6;
        }
        if (score == lock7 && tpTrue != 7)
        {
            wave7.SetActive(true);
            player.transform.position = place;
            tpTrue = 7;
        }
        if (score == bossLock && tpTrue != 8)
        {
            leafo.SetActive(true);
            player.transform.position = place;
            tpTrue = 8;
        }
    }
}
