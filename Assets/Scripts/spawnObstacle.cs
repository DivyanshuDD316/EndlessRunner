using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawnObstacle : MonoBehaviour
{
    public Transform playerPos;
    public GameObject obstaclePrefab;
    public GameObject coinPrefab;
    public GameObject taptoStart;
    public GameObject gameOver;
    public GameObject scoreText;

    public float spawnInterval=2f;
    public float spawnTime=0f;
    public float coinTime=0f;

    // Start is called before the first frame update
    void Start()
    {
        taptoStart.SetActive(true);
        gameOver.SetActive(false);
        Time.timeScale=0f;
        scoreText.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime+=Time.deltaTime;
        coinTime+=Time.deltaTime;
        if(spawnTime>spawnInterval)
        {
            Spawn();
            spawnTime=0f;
        }
        if(coinTime>1f)
        {
            coinSpawn();
            coinTime=0f;
        }
        if(Input.GetKey(KeyCode.Mouse0))
        {
            gameStart();
        }
    }
    void Spawn()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-4.5f,4.5f),0f,playerPos.position.z+30f);
        Instantiate(obstaclePrefab,spawnPos,Quaternion.identity);
    }
    void coinSpawn()
    {
        Vector3 coinPos = new Vector3(Random.Range(-4.5f,4.5f),1f,playerPos.position.z+20f);
        Instantiate(coinPrefab,coinPos,Quaternion.Euler(90,0,0));
    }
    public void gameStart()
    {
        taptoStart.SetActive(false);
        Time.timeScale=1f;
    }
    public void Restart()
    {
        SceneManager.LoadScene("level1");
    }
    public void Quit()
    {
        Application.Quit();
    }
    
}
