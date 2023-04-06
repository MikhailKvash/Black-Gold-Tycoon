using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] private GameObject fish;
    [SerializeField] private Transform fishSpawnPoint;
    
    private List<Transform> _currentSpawnPoint;
    private int _randomSpawnPoint;
    private int _randomFishAmount;

    private void Awake()
    {
        _currentSpawnPoint = GetFishSpawnPoints();
        StartCoroutine(SpawnFish());
    }

    IEnumerator SpawnFish()
    { 
        _randomFishAmount = Random.Range(0, 3);
        _randomSpawnPoint = Random.Range(0, 5);
        
        switch (_randomFishAmount)
        {
            case 0:
            { 
                Instantiate(fish, _currentSpawnPoint[_randomSpawnPoint].position, Quaternion.identity);
            } 
                break;
            case 1:
            { 
                Instantiate(fish, _currentSpawnPoint[_randomSpawnPoint].position, Quaternion.identity); 
                Instantiate(fish, _currentSpawnPoint[_randomSpawnPoint].position, Quaternion.identity);
            }
                break;
            case 2:
            {
                Instantiate(fish, _currentSpawnPoint[_randomSpawnPoint].position, Quaternion.identity);
                Instantiate(fish, _currentSpawnPoint[_randomSpawnPoint].position, Quaternion.identity);
                Instantiate(fish, _currentSpawnPoint[_randomSpawnPoint].position, Quaternion.identity);
            }
                break;
        }
        yield return new WaitForSeconds(10f);
        StartCoroutine(SpawnFish()); 
    }
    
    private List<Transform> GetFishSpawnPoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in fishSpawnPoint)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }
}
