using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy;

    [Header("Universal")]

    public float range = 15f;

    [Header("Bullet Stats")]

    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;


    [Header("Lazer Stats")]
    public bool useLazer = false;
    public int damageOverTime = 20;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;

    [Header("Requirements")]

    public string enemyTag = "Enemy";
    public Transform turnPoint;
    public float turnSpeed = 5f;

    public Transform firepoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float shortestDistance = Mathf.Infinity;

        GameObject nearestEnemy= null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            if(useLazer)
            {
                if(lineRenderer.enabled)
                {
                    impactEffect.Stop();
                    lineRenderer.enabled = false;
                    impactLight.enabled = false;
                }
            }
            return;
        }

        LockOnTarget();

        if(useLazer)
        {
            Lazer();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(turnPoint.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        turnPoint.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Lazer()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled= true;
            impactEffect.Play();
            impactLight.enabled = true;   
        }

        lineRenderer.SetPosition(0, firepoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firepoint.position - target.position;

        impactEffect.transform.position = target.position + dir.normalized * .5f;

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Bullet bullet= bulletGO.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
