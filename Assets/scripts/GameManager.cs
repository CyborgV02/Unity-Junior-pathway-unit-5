using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

  public List<GameObject> targets;
  private float spawnRate=1.0f;
 
    void Start()
    {
        StartCoroutine(SpawnObjects());
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

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    
}
