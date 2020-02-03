using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uiManager : MonoBehaviour
{
    public static uiManager instance;

    public GameObject panelLogo;
    public GameObject panelSkor;
    public GameObject panelGameOver;
    public GameObject tapToPlay;
    public GameObject liveScoreUI;
    public GameObject koin;
    public Text score;
    public Text liveScore;
    public Text topScoreMenu;
    public Text topScoreGameOver;
    public Text koinText;
    public Text currentScore;
    public Text currentBomb;
    // Start is called before the first frame update
    void Awake(){
        if(instance == null){
            instance = this;
        }
    }

    void Start()
    {
        if(PlayerPrefs.HasKey("topScore")){
            topScoreMenu.text = PlayerPrefs.GetInt("topScore").ToString();
        }else{
            topScoreMenu.text = "0";
        }
    }

    public void GameStart(){
        liveScoreUI.SetActive(true);
        koin.SetActive(true);
        tapToPlay.SetActive(false);
        panelLogo.GetComponent<Animator>().Play("logoNaik");
        panelSkor.GetComponent<Animator>().Play("panelSkorTurun");
    }

    public void GameOver(){
        int totalScore = PlayerPrefs.GetInt("score") + PlayerPrefs.GetInt("koin");
        score.text = totalScore.ToString();
        topScoreGameOver.text = PlayerPrefs.GetInt("topScore").ToString();

        panelGameOver.SetActive(true);
        liveScoreUI.SetActive(false);
        koin.SetActive(false);
    }

    public void Reset() {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        liveScore.text = PlayerPrefs.GetInt("score").ToString();
        koinText.text = PlayerPrefs.GetInt("koin").ToString();
        currentScore.text = PlayerPrefs.GetInt("score").ToString();
        currentBomb.text = PlayerPrefs.GetInt("koin").ToString();
    }
}
