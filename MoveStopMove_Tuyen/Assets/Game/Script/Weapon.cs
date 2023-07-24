using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float speed;
    protected Bullet bullet;

    public void MoveTo(Vector3 destinantion)
    {
        transform.position = Vector3.MoveTowards(transform.position, destinantion, speed * Time.deltaTime);
    }

    public abstract IEnumerator ShootProcessing(Vector3 destinantion);
    public void Shoot(Vector3 destination)
    {
        StartCoroutine(ShootProcessing(destination));
    }
}