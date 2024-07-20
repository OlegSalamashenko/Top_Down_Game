using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour, IEnemy
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletMoveSpeed;
    [SerializeField] private int burstCount;
    [SerializeField] private int projectilesPerBurst;
    [SerializeField][Range(0, 359)] private float angleSpread;
    [SerializeField] private float startingDistance = 0.1f;
    [SerializeField] private float timeBetweenBursts;
    [SerializeField] private float restTime = 1f;

    private bool isShoting = false;
    public void Attack()
    {
        if (!isShoting)
        {
            StartCoroutine(ShootRoutine());
        }
    }

    private IEnumerator ShootRoutine()
    {
        isShoting = true;

        float startAngle, currentAngle, angleStep;

        TargetConeOfInfluence(out startAngle, out currentAngle,out angleStep);

        for (int i = 0; i < burstCount; i++)
        {
            for (int j = 0; j < projectilesPerBurst; j++) 
            { 
                Vector2 pos = FindBulletSpawnPos(currentAngle);

                GameObject newBullet = Instantiate(bulletPrefab , pos , Quaternion.identity);
                newBullet.transform.right = newBullet.transform.position - transform.position;

                if (newBullet.TryGetComponent(out Projectile projectile))
                {
                    projectile.UpdateMoveSpeed(bulletMoveSpeed);
                }
                currentAngle += angleStep;
            }

            currentAngle = startAngle;
            yield return new WaitForSeconds(timeBetweenBursts);
            TargetConeOfInfluence(out startAngle, out currentAngle, out angleStep);

        }
        yield return new WaitForSeconds(restTime);
        isShoting = false;
    }


    private void TargetConeOfInfluence(out float startAngle, out float currentAngle, out float angleStep)
    {
        Vector2 targetDirection = PlayerController.Instance.transform.position - transform.position;
        float targetAngle = Mathf.Atan2(targetDirection.y,targetDirection.x) * Mathf.Rad2Deg;
        startAngle = targetAngle;
        float endAngle = targetAngle;
        currentAngle = targetAngle;
        float haflAngleSpread = 0f;
        angleStep = 0;
        if (angleSpread != 0)
        {
            angleStep = angleSpread / (projectilesPerBurst - 1);
            haflAngleSpread = angleSpread / 2f;
            startAngle = targetAngle - haflAngleSpread;
            endAngle = targetAngle + haflAngleSpread;
            currentAngle = startAngle;
        }
    }

    private Vector2 FindBulletSpawnPos(float currentAngle)
    {
        float x = transform.position.x + startingDistance * Mathf.Cos(currentAngle * Mathf.Rad2Deg);
        float y = transform.position.y + startingDistance * Mathf.Sin(currentAngle * Mathf.Rad2Deg);

        Vector2 pos = new Vector2(x, y);

        return pos;
    }
}