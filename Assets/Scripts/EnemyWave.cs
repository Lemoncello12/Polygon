using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    public GameObject wave2;
    public GameObject wave3;
    public GameObject wave4;
    public GameObject wave5;
    public GameObject leafo;
    public int lock2 = 7;
    public int lock3 = 17;
    public int lock4 = 29;
    public int lock5 = 42;
    public int bossLock = 59;
    private scoregame scoreGet;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        scoreGet = GameObject.Find("Player").GetComponent<scoregame>();
    }

    // Update is called once per frame
    void Update()
    {
       score = scoreGet.score;
        if (score == lock2)
        {
            wave2.SetActive(true);

        }
        if (score == lock3)
        {
            wave3.SetActive(true);
        }
        if (score == lock4)
        {
            wave4.SetActive(true);
        }
        if (score == lock5)
        {
            wave5.SetActive(true);
        }
        if (score == bossLock)
        {
            leafo.SetActive(true);
        }
    }
}
