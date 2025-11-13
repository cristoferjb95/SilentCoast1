using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    // Player's health and sanity values
    public float health = 100f;
    public float sanity = 100f;

    // Method to apply damage to the player
    public void TakeDamage(float amount)
    {
        health -= amount;
        health = Mathf.Clamp(health, 0, 100);
        // Additional logic for health changes
        if (health == 0)
        {
            Die();
        }
    }

    // Method to regenerate health
    public void Heal(float amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, 100);
    }

    // Method to affect sanity
    public void AffectSanity(float amount)
    {
        sanity += amount;
        sanity = Mathf.Clamp(sanity, 0, 100);
        // Additional logic for sanity changes
        if (sanity == 0)
        {
            LoseSanity();
        }
    }

    // Method to handle player death
    private void Die()
    {
        Debug.Log("Player has died.");
        // Implement death behavior here
    }

    // Method for losing sanity
    private void LoseSanity()
    {
        Debug.Log("Player has lost sanity.");
        // Implement sanity loss behavior here
    }
}