using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected float speed;
    protected bool hasWeapon = true;
    protected GameObject curWeapon;
    protected Bullet curBullet;

    public Bullet CurBullet { get { return curBullet; } set { curBullet = value; } }
    protected void Shoot()
    {
        if (!hasWeapon)
        {
            return;
        }
        float x = Random.Range(-25f, 25f);
        float z = Random.Range(-25f, 25f);
        Vector3 target = new Vector3(x, 2f + 0.25f, z);
        transform.LookAt(new Vector3(target.x, transform.position.y, target.z));
        curWeapon.GetComponent<Weapon>().Shoot(target);
        hasWeapon = false;
    }

    protected void SetStateToStop()
    {

    }

    protected void SetStateToMove()
    {
        if (hasWeapon == false)
        {
            hasWeapon = true;
            GetNewWeapon();
        }
    }

    private void Awake()
    {
        
    }
    protected void GetNewWeapon()
    {
        curWeapon = MySingleton<MyPool>.Instance.Pop(curBullet);
        curWeapon.transform.SetParent(transform);
        curWeapon.transform.localEulerAngles = Vector3.zero;
        curWeapon.transform.localPosition = new Vector3(0f, 2.5f, 0);
    }

}
