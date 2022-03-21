using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int Score = 0;
    public int maxScore = 10;

    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("Canvas/ScoreText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreText != null)
        {
            scoreText.text = Score.ToString();
        }

        if(Score >= maxScore)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void AddScore()
    {
        Score++;
    }
}
