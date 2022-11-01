using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject _pointPrefab;
    private int _scoreToSpeed = 100;

    public GameObject _gameoverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        _scoreToSpeed = 100;
        Time.fixedDeltaTime = .25f;
    }

    // Update is called once per frame
    void Update()
    {
        if(ScoreScript._score >= _scoreToSpeed)
        {
            Debug.Log("added");
            Time.fixedDeltaTime -= .05f;
            _scoreToSpeed += 1000;
        }
        //spawning points (old version, new one in PointScript.SetRandomPosition())
        /*if(GameObject.Find("Point(Clone)") == null){
            Vector2 spawnPosition = new Vector2(Random.Range(-16, 16), Random.Range(-8, 8));

            Instantiate(_pointPrefab, spawnPosition, Quaternion.identity);
        }*/
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        _gameoverCanvas.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void Play()
    {
        Restart();
    }
    public void Exit()
    {
        Application.Quit(0);
    }
}
