using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Weapon
{
    public override IEnumerator ShootProcessing(Vector3 destinantion)
    {
        transform.SetParent(null);
        transform.LookAt(new Vector3(destinantion.x, transform.position.y, destinantion.z));
        while (true)
        {
            //Debug.Log(Vector3.Distance(destinantion, transform.position));
            if (Vector3.Distance(destinantion, transform.position) < 1e-3)
            {
                break;
            }
            else
            {
                MoveTo(destinantion);
                //Debug.Log("-->Move");
                yield return null;
            }
        }
        MySingleton<MyWeaponPool>.Instance.Push(gameObject, base.bullet);
    }
}
