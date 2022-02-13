using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")] 
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs; // lista di GameObject che contiene i nemici della wave
    [SerializeField] Transform pathPrefab; // oggetto della classe Transform
    [SerializeField] float moveSpeed = 5f; // variabile float che rappresenta la velocità di movimemto d del nemico
    [SerializeField] float timeBetweenEnemySpawns = 1f; // variabile float che rappresenta il tempo "standard" di comparsa dei nemici su schermo
    [SerializeField] float spawnTimeVariance = 0f; // variabile float che rappresenta il tempo che fa variare la comparsa dei nemici sullo schermo
    [SerializeField] float minimumSpawnTime = 0.2f; // variabile che indica il tempo minimo di comparsa sullo schermo

    public int GetEnemyCount() // metodo che ritorna il numero di nemici della wave corrente
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index) // metodo che ritorna l'oggetto del nemico della wave corrente in quella posizione della wave
    {
        return enemyPrefabs[index];
    }

    public Transform GetStartingWaypoint() // metodo che ritorna la posizione, la ritazione e la scala del primo waypoint della wave
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints() // metodo che ritorna la posizione, la ritazione e la scala di tutti i waypoint della wave sotto forma di lista
    {
        List<Transform> waypoints = new List<Transform>(); // crea una lista di classe Transform dei nome waypoint
        foreach(Transform child in pathPrefab) // ciclo che aggiunge alla lista nuovi waypoint fino ad inserirli tutti
        {
            waypoints.Add(child);
        }
        return waypoints; // ritorna la lista
    }

    public float GetMoveSpeed() // metodo che ritona la velocità di movimeno dei nemici
    {
        return moveSpeed;
    }

    public float GetRandomSpawnTime() // metodo che fa in modo che i nemici vengano generati con un tempo casuale tra alcuni valori
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance, timeBetweenEnemySpawns + spawnTimeVariance); // genera un tempo pseudocasuale
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue); // restituisce il risultato come float
    }
}
