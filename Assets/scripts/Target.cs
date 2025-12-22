using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    float minSpeed=12.0f;
    float maxSpeed=16.0f;
    float Torque=3.0f;
    float spawnRangeX=4.0f;
    float spawnPosY=-2.0f;
    private Rigidbody targetRB;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem explosionParticle;
    void Start()
    {
        targetRB=GetComponent<Rigidbody>();
        targetRB.AddForce(randomForce(),ForceMode.Impulse);
        targetRB.AddTorque(randomTorque(),randomTorque(),randomTorque(),ForceMode.Impulse);
        transform.position=(randomSpawnPos());
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }
    void OnMouseDown()
    {
        if(gameManager.isGameActive){
        gameManager.updateScore(pointValue);
        Instantiate(explosionParticle,transform.position,explosionParticle.transform.rotation);
         Destroy(gameObject);
        }
    }
    void Update()
    {
        
    }
    Vector3 randomForce()
    {
        return Vector3.up*Random.Range(minSpeed,maxSpeed);
    }

    float randomTorque()
    {
        return Random.Range(-Torque,Torque);
    }

    Vector3 randomSpawnPos()
    {
        return new Vector3(Random.Range(-spawnRangeX,spawnRangeX),spawnPosY);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.isGameActive=false;
            gameManager.gameOver();
        }
    }
}
