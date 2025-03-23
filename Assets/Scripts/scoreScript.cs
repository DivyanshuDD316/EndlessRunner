using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text finalScoreText;
    int myScore=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text=myScore.ToString();
        finalScoreText.text="Score: "+myScore.ToString();
    }
    public void AddScore(int add)
    {
        myScore+=add;
    }
}
