using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // libreria di unity che permette il campio delle scene di gioco

public class LevelManager : MonoBehaviour
{
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>(); // cerca il primo oggetto della classe ScoreKeeper e lo mette dentro la variabile scoreKeeper
    }

    [SerializeField] float sceneLoadDelay = 0.5f; // variabile che imposta un delay tra il cambio di una scena e l'altra
    public void LoadGame() // metodo che carica la scena "The Game", il gioco vero e proprio
    {
        SceneManager.LoadScene("TheGame");
        scoreKeeper.ResetScore();
    }

    public void LoadMainMenu() // metodo che carica la scena "MainMenu", il menù iniziale
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameOver()// metodo che carica la scena "GameOver", la fine del gioco
    {
        StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay)); // il passaggio tra la scena precedente e quella successiva ha un delay
    }

    public void LoadQuit() // metodo che carica la scena "Quit", La schermata di quit
    {
        Debug.Log("Quitting Game..."); // invia il messaggio sulla console
        SceneManager.LoadScene("Quit");
    }

    public void QuitGame() // metodo che fa uscire definitivamente dal gioco
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay) // metodo che crea un delay tra una scena e la successiva
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}

