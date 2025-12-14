using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
  public TextMeshProUGUI scoreText;
  public List<GameObject> targets;
  public float score=0;
  private float spawnRate=1.0f;
 
    void Start()
    {
        StartCoroutine(SpawnObjects());

        updateScore(0);
        
    }
   
    void Update()
    {
        
    }

    IEnumerator SpawnObjects()
    {
        while (true)
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

  
}
