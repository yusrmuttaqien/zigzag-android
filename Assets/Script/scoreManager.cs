using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreManager : MonoBehaviour
{
    public static scoreManager instance;
    public int score;
    public int topScore;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void tambahScore()
    {
        score += 1;

        PlayerPrefs.SetInt("score", score);
    }

    public void mulaiScore()
    {
        InvokeRepeating("tambahScore", .1f, 2f);
    }

    public void stopScore()
    {
        CancelInvoke("tambahScore");

        int koin = PlayerPrefs.GetInt("koin");

        if (PlayerPrefs.HasKey("topScore"))
        {
            if(score+koin > PlayerPrefs.GetInt("topScore")){ 
                PlayerPrefs.SetInt("topScore", score+koin);
            }
        }
        else
        {
            PlayerPrefs.SetInt("topScore", score+koin);
        }
    }
}
