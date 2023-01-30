using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    public float range = 15f;
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    private float turnSpeed = 6.5f;
    [SerializeField] private float fireRate = 1f;
    private float fireCountdown = 0f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    void Start()
    {

        //fct update customisable
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearstEnemy = null;
        foreach (GameObject enemy in enemys)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearstEnemy = enemy;
            }
        }
    if(nearstEnemy != null && shortestDistance <= range)
        {
            target = nearstEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {

        //Rotation
        if(target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime*turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        //Fire
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1 / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }
}
