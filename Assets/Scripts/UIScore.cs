using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScore : MonoBehaviour
{
    public static int score = 0;
    
    Text ScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + score;

        if (score < 0)
        {
            score = 0;
            SceneManager.LoadScene("GameOver");
            //Debug.Log("Game Over");
        }

    }
}
