using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;

    [HideInInspector]
    public float speed = 10f;
    public float health = 100;
    public int worth = 50;
    public GameObject deathEffect;

    public void Start()
    {
        speed = startSpeed;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        GameObject deathParticules = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(deathParticules, 2f);
        PlayerStats.money += worth;
        Destroy(gameObject);
    }

   public void  Slow( float aount)
    {
        speed = startSpeed * (1f - aount);
    }
}
