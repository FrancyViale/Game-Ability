using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // libreria di unity che serve a gestire gli input

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f; // velocità di movimento 
    Vector2 rawInput;

    [SerializeField] float paddingLeft; // padding sinistro
    [SerializeField] float paddingRight; // padding destro
    [SerializeField] float paddingTop; // padding in alto
    [SerializeField] float paddingBottom; // padding in basso
    
    Vector2 minBounds;
    Vector2 maxBounds;

    Shooter shooter; // oggetto della classe Shooter

    void Awake()
    {
        shooter = GetComponent<Shooter>(); // restituisce l'oggetto della classe Shooter l'asset di gioco ne ha uno collegato
    }

    void Start()
    {
        InitBounds(); // inizializza i bordi che il player non può attraversare
    }

    void Update()
    {
        Move(); // muove il 
    }

    void InitBounds() // serve a delineare dei limiti che il player non può superare
    {
        Camera mainCamera = Camera.main; 
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }

    void Move()
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime; // calcola la disatanza da percorrere. parametri: è in movimento (0, 1), velocità di movimento, l'intervallo in secondi dall'ultimo fotogramma a quello corrente
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight); // cambia la posizione dell'asse x per la posizione del protagonista 
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop); // cambia la posizione dell'asse y per la posizione del protagonista 
        transform.position = newPos; // cambia la posizione del protagonista
    }

    void OnMove(InputValue value) // metodo che serve a comprendere se il protagonista è in movimento
    {
        rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value) // metodo che, se premuto il tasto corrispondente, fa sparare il player
    {
        if(shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }
}
