using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score; // variabile int che rappresenta il punteggio del giocatore

    static ScoreKeeper instance; // l'oggetto instance non crea un istanza della classe ScoreKeeper

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if(instance != null) // se l'oggetto non è null
        {
            gameObject.SetActive(false); // disattiva l'oggetto
            Destroy(gameObject); // distrugge l'oggetto
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // non distrugge l'oggetto quando si carica una nuova scena
        }
    }

    public int GetScore() // il metodo restituisce il punteggio del giocatore
    {
        return score;
    }

    public void ModifyScore(int value) // il metodo modifica il punteggio del valore passato tra parametri
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue); // parametri: il valore da limitare all'interno dell'intervallo definito dai valori min e max, min, max
        Debug.Log(score); // stampa il punteggio sulla console
    }

    public void ResetScore()
    {
        score = 0;
    }
}
