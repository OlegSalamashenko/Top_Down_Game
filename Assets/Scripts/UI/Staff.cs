using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour , IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private GameObject magicLaser;
    [SerializeField] private Transform magicLaserSpawnPoint;

    private Animator myAnimator;

    readonly int Attack_HASH = Animator.StringToHash("Attack");

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        MouseFollowWithOffset();
    }
    public void Attack()
    {
        myAnimator.SetTrigger(Attack_HASH);
    }

    public void SpawnStaffProjectileAnimEvent()
    {
        GameObject newLaser = Instantiate(magicLaser,magicLaserSpawnPoint.position,Quaternion.identity);
        newLaser.GetComponent<MagicLazer>().UpdateLaserRange(weaponInfo.weaponRange);
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }
    private void MouseFollowWithOffset()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(PlayerController.Instance.transform.position);

        Vector3 direction = mousePos - playerScreenPoint;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


        if (PlayerController.Instance.FacingLeft)
        {
            ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, -180f, -angle + 180);
        }
        else
        {
           ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }


    

}
