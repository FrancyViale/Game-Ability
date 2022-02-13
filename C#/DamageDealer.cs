using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 10; // creo la variabile damage con valore intero 10

    public int GetDamage()
    {
        return damage; // Ritorna il valore della variabile damage
    }

    public void Hit()
    {
        Destroy(gameObject); // Distrugge l'oggetto colpito
    }
}

