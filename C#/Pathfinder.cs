using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemySpawner; // oggetto della classe EnemySpawner
    WaveConfigSO waveConfig; // oggetto della classe WaveConfigSO
    List<Transform> waypoints; // lista della classe Transform
    int waypointIndex = 0; // indice

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>(); // cerca il primo oggetto della classe EnemySpawner e lo mette dentro la variabile enemySpawner
    }

    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave(); // inizializza l'oggetto waveConfig restituendo la wave corrente
        waypoints = waveConfig.GetWaypoints(); // inizializza la lista waypoints restituendo il waypoint corrente
        transform.position = waypoints[waypointIndex].position; // salva la posizione del waypoint successivo dentro la variabile transform.position
    }

    void Update()
    {
        FollowPath(); // aggiorna il waypoint successivo da seguire
    }

    void FollowPath()
    {
        if(waypointIndex < waypoints.Count) // se il waypoint corrente è minore del numero di waypoint
        {
            Vector3 targetPosition = waypoints[waypointIndex].position; // salva la posizione dell'asset dentro un vettore
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime; // la velocità * l'intervallo in secondi dall'ultimo fotogramma a quello corrente = spazio da percorrere
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta); // cambia la posizione dell'asset. parametri: waypoint attuale, waypoint successivo, spazio da percorrere
            if(transform.position == targetPosition) // se waypoint attuale e waypoint successivo sono uguali 
            {
                waypointIndex++; // aumenta indice 
            }
        }
        else
        {
            Destroy(gameObject); // distruggi asset
        }
    }
}
