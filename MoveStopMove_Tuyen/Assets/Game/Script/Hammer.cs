using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : Weapon
{
    [SerializeField] float rotateSpeed;
    public override IEnumerator ShootProcessing(Vector3 destinantion)
    {
        transform.SetParent(null);
        transform.LookAt(new Vector3(destinantion.x, transform.position.y, destinantion.z));
        while (true)
        {
            //Debug.Log(Vector3.Distance(destinantion, transform.position));
            if (Vector3.Distance(destinantion, transform.position) < 1e-3)
            {
                MySingleton<MyWeaponPool>.Instance.Push(gameObject, bullet);
                //Debug.Log("-->Push");
                break;
            }
            else
            {
                MoveTo(destinantion);
                transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + rotateSpeed * Time.deltaTime, transform.eulerAngles.z));
                //Debug.Log("-->Move");
                yield return null;
            }
        }
        MySingleton<MyWeaponPool>.Instance.Push(gameObject, bullet);
    }
}
