using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText; // oggetto della classe TextMeshProUGUI
    ScoreKeeper scoreKeeper; // oggetto della classe ScoreKeeper

    void Awake() 
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();  // cerca il primo oggetto della classe ScoreKeeper e lo mette dentro la variabile scoreKeeper
    }

    void Start()
    {
        scoreText.text = scoreKeeper.GetScore().ToString(); // stampa come testo il punteggio finale del giocatore
    }

}
