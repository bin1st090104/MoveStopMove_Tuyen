using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : Weapon
{
    [SerializeField] private float rotateSpeed;
    public override IEnumerator ShootProcessing(Vector3 destinantion)
    {
        Vector3 startPoint = transform.position;
        transform.SetParent(null);
        transform.LookAt(new Vector3(destinantion.x, transform.position.y, destinantion.z));
        while (true)
        {
            //Debug.Log(Vector3.Distance(destinantion, transform.position));
            if (Vector3.Distance(destinantion, transform.position) < 1e-3)
            {
                break;
            }
            MoveTo(destinantion);
            //Debug.Log("-->Move");
            yield return null;
        }
        Vector3 targetEulerAngles = transform.eulerAngles + new Vector3(0f, 180f, 0f);
        if(targetEulerAngles.y >= 360)
        {
            targetEulerAngles.y -= 360;
        }
        while (true)
        {
            //Debug.Log(targetEulerAngles.y + "   " + transform.eulerAngles.y + "   " + Mathf.Abs(targetEulerAngles.y - transform.eulerAngles.y));
            if (Mathf.Abs(targetEulerAngles.y - transform.eulerAngles.y) < 1e-2)
            {
                break;
            }
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetEulerAngles), rotateSpeed * Time.deltaTime);
            yield return null;
        }
        Debug.Log("Finish rotate");
        while (true)
        {
            if (Vector3.Distance(startPoint, transform.position) < 1e-3)
            {
                break;
            }
            MoveTo(startPoint);
            //Debug.Log("-->Move");
            yield return null;
        }
        MySingleton<MyWeaponPool>.Instance.Push(gameObject, base.bullet);
    }
}
