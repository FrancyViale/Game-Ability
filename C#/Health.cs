using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer; // variabile bool che indica se l'asset è il giocatore o meno
    [SerializeField] int health = 50; // variabile int che rappresenta la vita dell'asset
    [SerializeField] int score = 50; // variabile int che rappresenta quanti punti riceve il giocatore se colpisce l'asset
    [SerializeField] ParticleSystem hitEffect; // oggetto di tipo ParticleSystem che rappresenta l'effetto di "esplosione" quando viene colpito l'asset

    ScoreKeeper scoreKeeper; // oggetto di tipo ScoreKeeper che serve a matenere il punteggio della partita corrente

    void Awake() 
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>(); // restituisce il primo oggetto di tipo ScoreKeeper dentro la variabile scoreKeeper
    }

    void OnTriggerEnter2D(Collider2D other) // questo metodo 
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(damageDealer != null) // se il danno è diverso da null 
        {
            TakeDamage(damageDealer.GetDamage()); // se l'asset colpito prende danno da rendere la sua vita <= 0 l'asset viene distrutto
            PlayHitEffect(); // vengono mostrate le particelle 
            damageDealer.Hit();  // l'asset colpito prende danno
        }
    }

    public int GetHealth() // restituisce la variabile health
    {
        return health;
    }

    void TakeDamage(int damage) // se l'asset colpito prende danno da rendere la sua vita <= 0 l'asset viene distrutto
    {
        health -= damage; // diminuisce la vita dell'asset
        if(health <= 0) // se è <= 0 
        {
            Die(); // l'asset "muore"
        }
    }

    void Die() // metodo che fa in modo 
    {
        if(!isPlayer) // se l'asset colpito non è il giocatore 
        {
            scoreKeeper.ModifyScore(score); // modifica il punteggio del giocatore del valore del nemico colpito
        }
        Destroy(gameObject); // distrugge l'asset colpito
    }
    
    void PlayHitEffect() // metodo che fa comparire a schermo gli effetti particellari quando un asset vienen colpito
    {
        if(hitEffect != null) // se viene colpito qualcosa
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity); // fa apparire gli effetti particellari dove è stato colpito l'asset
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax); // fa scomparire dopo qualche istante gli effetti particellari
        }
    }
}
