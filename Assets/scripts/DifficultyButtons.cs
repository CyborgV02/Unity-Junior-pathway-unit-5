using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtons : MonoBehaviour
{
   private Button button;
   private GameManager gameManager;
   public int difficulty=1;
    void Start()
    {
        button=GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
    }

 
   void SetDifficulty()
    {
        Debug.Log(gameObject.name + " Was clicked");
        gameManager.startGame(difficulty);

    }
}
