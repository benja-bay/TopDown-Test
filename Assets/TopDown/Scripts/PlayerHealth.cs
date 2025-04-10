using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Configuración de vida")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int minHealth = 0;
    [SerializeField] private int startHealth = 100;

    private int currentHealth;

    private void Awake()
    {
        // Mathf.Clamp(valor, mínimo, máximo) se asegura de que startHealth esté entre minHealth y maxHealth.
        currentHealth = Mathf.Clamp(startHealth, minHealth, maxHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, minHealth);
        // Mathf.Max se asegura de que no baje de minHealth.

        Debug.Log($"Jugador recibió {amount} de daño. Vida actual: {currentHealth}");

        if (currentHealth <= minHealth)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        Debug.Log($"Jugador curado. Vida actual: {currentHealth}");
    }

    public void SetHealth(int value)
    {
        currentHealth = Mathf.Clamp(value, minHealth, maxHealth);
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    private void Die()
    {
        Debug.Log("El jugador ha muerto.");
        // Aquí podrías desactivar al jugador, reiniciar la escena, mostrar un menú de derrota, etc.
    }
}
