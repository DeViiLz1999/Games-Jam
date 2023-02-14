using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] MutantOneGameObject;
    public GameObject[] MutantTwoGameObject;

    public float startWaitTime;
    public float spawnWaitTime;

    private float spawnTime;

    GameObject MutantOne, MutantTwo;

    float[] XPosition = new float[2] {1.5f, 4.6f};

    bool GameOverbool;

    int Score;
    public Text ScoreText;

    public GameObject GameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        GameOverbool = false;
        Time.timeScale = 1;
        GameOverCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //spawnTime += Time.deltaTime;
        spawnWaitTime = Mathf.Pow(0.9f, Time.timeSinceLevelLoad / 5f);
    }

    IEnumerator SpawnObjects()
    {
        yield return new WaitForSeconds(startWaitTime);
        while(true)
        {
            for (int i=0; i<50; i++)
            {
                float MutantOneXPos = -XPosition[Random.Range(0, XPosition.Length)];
                Vector3 MutantOnePos = new Vector3(MutantOneXPos, 10, 0);
                MutantOne = MutantOneGameObject[Random.Range(0, MutantOneGameObject.Length)] as GameObject;
                Instantiate(MutantOne, MutantOnePos, Quaternion.identity);
                yield return new WaitForSeconds(spawnWaitTime);    

                float MutantTwoXPos = XPosition[Random.Range(0, XPosition.Length)];
                Vector3 MutantTwoPos = new Vector3(MutantTwoXPos, 10, 0);
                MutantTwo = MutantTwoGameObject[Random.Range(0, MutantTwoGameObject.Length)] as GameObject;
                Instantiate(MutantTwo, MutantTwoPos, Quaternion.identity);
                yield return new WaitForSeconds(spawnWaitTime);            
            }

            /*if (spawnTime == 12f)
            {
                spawnWaitTime = .65f;
                yield return new WaitForSeconds(spawnWaitTime);
            }

            if (spawnTime == 25f)
            {
                spawnWaitTime = .55f;
                yield return new WaitForSeconds(spawnWaitTime);
            }*/
        }
    }

    public void StartGame()
    {
        StartCoroutine(SpawnObjects());
    }


    public void GameOver()
    {
        GameOverbool = true;
        Time.timeScale = 0;
        GameOverCanvas.SetActive(true);
    }

    public void QuitGame()
    {
     #if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
     #else
         Application.Quit();
     #endif
        Debug.Log("QuitGame");
    }

    public void AddScore()
    {
        Score += 1;
        ScoreText.text = Score.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
