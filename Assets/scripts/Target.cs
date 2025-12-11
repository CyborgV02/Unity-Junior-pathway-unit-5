using UnityEditor.Callbacks;
using UnityEngine;

public class Target : MonoBehaviour
{
    float minSpeed=12.0f;
    float maxSpeed=16.0f;
    float Torque=5.0f;
    float spawnRangeX=4.0f;
    float spawnPosY=-2.0f;
    private Rigidbody targetRB;
    void Start()
    {
        targetRB=GetComponent<Rigidbody>();

        targetRB.AddForce(randomForce(),ForceMode.Impulse);
        targetRB.AddTorque(randomTorque(),randomTorque(),randomTorque(),ForceMode.Impulse);
        transform.position=(randomSpawnPos());
    }
    void OnMouseDown()
    {
        Destroy(gameObject);
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
    }
}
