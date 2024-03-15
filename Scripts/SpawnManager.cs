using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float minTime = 1f;
    public float maxTime = 2f;
    public GameObject gruntPrefab;
    public List<Transform> respawnPoints = new List<Transform>(); // Lista de puntos de respawn

    void Start()
    {
        // Crear objetos vacíos y agregarlos a la lista respawnPoints
        for (int i = 0; i < 5; i++) // Crear 5 puntos de respawn
        {
            GameObject emptyObject = new GameObject("RespawnPoint" + i);
            emptyObject.transform.position = new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f)); // Posición aleatoria
            respawnPoints.Add(emptyObject.transform);
        }

        StartCoroutine(SpawnCoRoutine());
    }

    IEnumerator SpawnCoRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));

            if (respawnPoints.Count > 0)
            {
                Transform randomSpawnPoint = respawnPoints[Random.Range(0, respawnPoints.Count)];

                // Instanciar el enemigo Grunt en el punto de respawn aleatorio
                GameObject newGrunt = Instantiate(gruntPrefab, randomSpawnPoint.position, Quaternion.identity);

                GruntScript gruntScript = newGrunt.GetComponent<GruntScript>();
                if (gruntScript != null)
                {
                    gruntScript.SetRespawnPoint(randomSpawnPoint);
                }
            }
            else
            {
                Debug.LogError("No hay puntos de respawn definidos en la lista respawnPoints.");
            }
        }
    }

    public void AddRespawnPoint(Transform point)
    {
        respawnPoints.Add(point);
    }
}
