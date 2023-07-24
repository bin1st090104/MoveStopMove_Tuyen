using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected Body body;
    [SerializeField] protected RangeAttack rangeAttack;
    [SerializeField] protected float originalRangeAttackSize;
    protected bool hasWeapon = false;
    protected GameObject curWeapon;
    protected Bullet curBullet;

    public Bullet CurBullet { get { return curBullet; } set { curBullet = value; } }
    protected void Shoot()
    {
        if (!hasWeapon)
        {
            return;
        }
        Character targetCharacter = rangeAttack.GetEarliestCharacter();
        if(targetCharacter == null)
        {
            return;
        }
        Vector3 target = targetCharacter.transform.position;
        transform.LookAt(new Vector3(target.x, transform.position.y, target.z));
        curWeapon.GetComponent<Weapon>().Shoot(target);
        hasWeapon = false;
    }
    public void SetStatusToDead()
    {
        gameObject.SetActive(false);
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
        curWeapon = MySingleton<MyWeaponPool>.Instance.Pop(curBullet);
        curWeapon.transform.SetParent(transform);
        curWeapon.transform.localEulerAngles = Vector3.zero;
        curWeapon.transform.localPosition = new Vector3(0f, 2.5f, 0);
    }

}
