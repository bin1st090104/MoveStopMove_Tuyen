using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected float speed;
    protected bool hasWeapon = true;
    private GameObject currentWeapon;

    protected void Shoot()
    {
        if (!hasWeapon)
        {
            return;
        }
        Vector3 target = new Vector3(Random.Range(-25, -25), 2f + 0.25f, Random.Range(-25, 25));
        currentWeapon.GetComponent<Weapon>().Shoot(target);
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
        currentWeapon = MySingleton<MyWeaponPool>.Instance.Pop();
        currentWeapon.transform.SetParent(transform);
        currentWeapon.transform.localPosition = new Vector3(0f, 2.5f, 0);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
