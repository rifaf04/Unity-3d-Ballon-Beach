using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {

    public int score;
    public int highScore;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI highScoreUI;

    void Start() {
        highScore = PlayerPrefs.GetInt("highscore");
    }

    // Update is called once per frame
    void Update () {
        scoreUI.text = score.ToString();
        highScoreUI.text = highScore.ToString();
        if (score > highScore) {
            highScore = score;
            PlayerPrefs.SetInt("highscore", highScore);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "scoreup") {
            score++;
        }
    }
}
