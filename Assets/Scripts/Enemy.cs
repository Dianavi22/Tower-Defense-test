using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;

    [HideInInspector]
    public float speed = 10f;
    public float startHealth = 100;
    private float health;
    public int worth = 50;
    public GameObject deathEffect;

    public Image healthBar;

    public void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;
        Debug.Log("Hp : " + health);
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
