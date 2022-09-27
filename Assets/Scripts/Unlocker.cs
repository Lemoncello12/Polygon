using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlocker : MonoBehaviour
{
    public GameObject unlockee;
    public int scoreToUnlock = 3;
    public scoregame theScore;
    // public int theScore = scoring.score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (theScore.score == scoreToUnlock)
        {
            unlockee.SetActive(true);
        }
    }
}
