using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs; // creo la lista waveConfigs di tipo della classe WaveConfigSO 
    [SerializeField] float timeBetweenWaves = 0f; // creo la variabile float timeBetweenWaves con valore iniziale 0
    [SerializeField] bool isLooping; // creo la variabile bool isLooping 
    WaveConfigSO currentWave; // l'oggetto rappresenta la wave che in quel momento è comparsa sullo schermo

    void Start() 
    {
        StartCoroutine(SpawnEnemyWaves()); // La funzione StartCoroutine permette di eseguire un'azione parallela, in questo caso una wave di nemici in movimento,                    
    }                                      // permettendole così di proseguire il proprio percorso per più fotogrammi fino a che non viene interrotta

    public WaveConfigSO GetCurrentWave() // Il metodo restituisce l'oggetto currentWave
    {
        return currentWave;
    }

    IEnumerator SpawnEnemyWaves() // IEnumerator permette di interrompere una coroutine quando viene restutuito un valore yield
    {                             // Il metodo permette di stampare la wave di nemici
        do
        {
            foreach (WaveConfigSO wave in waveConfigs) // il ciclo ha lo scopo di stampare tutti i nemici della wave
            {                                       
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++) // crea a schermo alcuni nemici 
                {
                    Instantiate(currentWave.GetEnemyPrefab(i), // crea il nemico. parametri: oggetto, la sua posizione nello spazio (3 dimensioni), la sua rotazione
                                currentWave.GetStartingWaypoint().position,
                                Quaternion.identity,
                                transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime()); // ferma la coroutine, la crezione di altri nemici, per il valore tra parametri
                }
                yield return new WaitForSeconds(timeBetweenWaves); // ferma la coroutine, la crezione di altri nemici, per il valore impostato dal programmatore
            }
        }
        while(isLooping); // ciclo infinito 
    }
}
