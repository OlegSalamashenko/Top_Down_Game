using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour , IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;
    private void Update()
    {
        MouseFollowWithOffset();
    }
    public void Attack()
    {
        Debug.Log("Staff Attack");
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
