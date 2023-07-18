using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private float radius = 5;
    public void SpawnObstacle(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector2 randomPoint = Random.insideUnitCircle * radius;
            Vector3 spawnPoint = transform.position + new Vector3(randomPoint.x, 0, randomPoint.y);

            GameObject temp = Instantiate(objectToSpawn, spawnPoint, Quaternion.identity);
            temp.transform.SetParent(transform);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
