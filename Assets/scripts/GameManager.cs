using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public TextMeshProUGUI scoreText;
  public TextMeshProUGUI gameOverText;
  public List<GameObject> targets;
  public float score=0;
  private float spawnRate=1.0f;
  public bool isGameActive=false;
  public Button restartButton;
 
    void Start()
    {
        isGameActive=true;
        StartCoroutine(SpawnObjects());

        updateScore(0);
        
    }
   
    void Update()
    {
        
    }

    IEnumerator SpawnObjects()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0,targets.Count);
            Instantiate(targets[index]);

        }
    }

    public void updateScore(int scoretoAdd)
    {
        score=score+scoretoAdd;
        scoreText.text="Score : "+ score;
    }

    public void gameOver()
    {
        isGameActive=false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

  
}
