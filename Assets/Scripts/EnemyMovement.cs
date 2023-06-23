using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform _target;
    private int _waypointIndex = 0;

    private Enemy _enemy;
    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _target = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = _target.position - transform.position;
        transform.Translate(dir.normalized * _enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= 0.3f)
        {

            GetNextWaypoint();
        }
        _enemy.speed = _enemy.startSpeed;
    }
    private void GetNextWaypoint()
    {
        if (_waypointIndex >= Waypoints.points.Length - 1)
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
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
