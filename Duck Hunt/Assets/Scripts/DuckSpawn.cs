using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DuckSpawn : MonoBehaviour
{
	public GameObject duck;
	public List<Transform> spawnPoints;

	void Start ()
	{
        GameManager.OnSpawnDucks += SpawnDuck;
//		spawnPoints = new List<Transform> ();
//		SetSpawnPoint.PassSpawnPointTransform += AddToSpawnPointsList;
	}
	

	void AddToSpawnPointsList(Transform _spawnPoint)
	{
		spawnPoints.Add (_spawnPoint);
	}


	public void SpawnDuck()
	{
		int randomSpawnPointNum = Random.Range (0, spawnPoints.Count-1);
		Instantiate(duck, spawnPoints[randomSpawnPointNum].position, Quaternion.identity);
        int randomSpawnPointNum2 = Random.Range(0, spawnPoints.Count - 1);
        Instantiate(duck, spawnPoints[randomSpawnPointNum2].position, Quaternion.identity);
    }

    private void OnDisable()
    {
        GameManager.OnSpawnDucks -= SpawnDuck;
    }
}
