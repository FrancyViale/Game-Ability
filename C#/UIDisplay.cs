using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText; // oggetto della classe TextMeshProUGUI
    ScoreKeeper scoreKeeper; // oggetto della classe ScoreKeeper

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>(); // cerca il primo oggetto della classe ScoreKeeper e lo mette dentro la variabile scoreKeeper
    }

    void Update()
    {
        scoreText.text = scoreKeeper.GetScore().ToString("00"); // il punteggio appena parte il gioco
    }
}
