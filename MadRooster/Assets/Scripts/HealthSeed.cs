using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSeed : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (other.gameObject.GetComponent<Player>().currentHealth < other.gameObject.GetComponent<Player>().maxHealth)
            { 
                other.gameObject.GetComponent<Player>().TakeDamage(other.gameObject.GetComponent<Player>().currentHealth - other.gameObject.GetComponent<Player>().maxHealth);
                Destroy(this.gameObject);
            }
        }
    }
}
