using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;

    // Start is called before the first frame update
    void Awake() {
        if(instance == null){
            instance = this;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart(){
        uiManager.instance.GameStart();
        scoreManager.instance.mulaiScore();
    }

    public void GameOver(){
        uiManager.instance.GameOver();
        scoreManager.instance.stopScore();
    }
}
