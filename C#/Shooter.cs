using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab; // asset del proiettile
    [SerializeField] float projectileSpeed = 10f; // variabile float che rappresenta la velocità del proiettile
    [SerializeField] float projectileLifetime = 5f; // variabile float che rappresenta la durata di vita del proiettile
    [SerializeField] float firingRate = 0.2f; // variabile float che rappresenta il tempo minimo tra la creazione di un proiettile e il successivo

    public bool isFiring; // variabile bool che indica se il player sta sparando senza che il giocatpre abbia premuto il tasto 
    Coroutine firingCoroutine; // oggetto della classe Coroutine

    void Update()
    {
        Fire(); // ogni frame controlla se il giocatore ha premuto il tasto per lo sparo
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null) // se il giocatore ha toccato il tasto adibito allo sparo
        {
            firingCoroutine = StartCoroutine(FireContinuously()); // il player inizia a sparare
        }
        else if(!isFiring && firingCoroutine != null) // se il giocatore non ha premuto il tasto per lo sparo e isFiring è true
        {
            StopCoroutine(firingCoroutine); // ferma la riaffica di proiettili
            firingCoroutine = null; // il player smette di sparare
        }
    }

    IEnumerator FireContinuously()
    {
        while(true) // ciclo infinito
        {
            GameObject instance = Instantiate(projectilePrefab, // crea il proiettile. parametri: oggetto, la sua posizione nello spazio (3 dimensioni), la sua rotazione
                                            transform.position, 
                                            Quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>(); // crea l'oggetto Rigidbody2D del proiettile
            if(rb != null) // se non ha colpito nulla 
            {
                rb.velocity = transform.up * projectileSpeed; // sposta il proiettile verso l'alto
            }

            Destroy(instance, projectileLifetime); // distrugge l'oggetto instance ma dopo projectileLifetime secondi
            yield return new WaitForSeconds(firingRate); // delay 
        }
    }
}


