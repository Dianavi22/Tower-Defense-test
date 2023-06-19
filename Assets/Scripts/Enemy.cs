using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    private Transform _target; 
    private int _waypointIndex = 0;
    public int health = 100;
    public int value = 50;
    public GameObject deathEffect;
    private void Start()
    {
        _target = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = _target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, _target.position) <= 0.3f)
        {

            GetNextWaypoint();
        }
    }

    public void TakeDamage(int amount)
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
        PlayerStats.money += value;
        Destroy(gameObject);
    }

    private void GetNextWaypoint()
    {
        if(_waypointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        _waypointIndex++;
        _target = Waypoints.points[_waypointIndex];
    }

    private void EndPath()
    {
        PlayerStats.lives--;
        Destroy(gameObject);
    }
}
