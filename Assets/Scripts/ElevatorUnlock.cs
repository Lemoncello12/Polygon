using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorUnlock : MonoBehaviour
{
    public GameObject self;
    public int scoreToUnlock = 3;
    public scoregame theScore;
   // public int theScore = scoring.score;

    // Start is called before the first frame update
    void Start()
    {
        theScore = GetComponent<scoregame>();
    }

    // Update is called once per frame
    void Update()
    {
        if (theScore.score == scoreToUnlock)
        {
            self.SetActive(true);
        }
    }
}
