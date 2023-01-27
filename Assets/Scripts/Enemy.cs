using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    private Transform _target; 
    private int _waypointIndex = 0;

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

    private void GetNextWaypoint()
    {
        if(_waypointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            print("GameOver");
            return;
        }
        _waypointIndex++;
        _target = Waypoints.points[_waypointIndex];
    }
}
