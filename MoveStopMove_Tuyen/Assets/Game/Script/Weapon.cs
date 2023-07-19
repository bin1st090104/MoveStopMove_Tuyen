using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float speed;

    private void MoveTo(Vector3 direct)
    {
        transform.position = Vector3.MoveTowards(transform.position, direct, speed * Time.deltaTime);
    }

    IEnumerator ShootProcessing(Vector3 destinantion)
    {
        while (true) {
            if(Vector3.Distance(destinantion, transform.position) <= 0.1)
            {
                MySingleton<MyWeaponPool>.Instance.Push(gameObject);
                yield break;
            }
            else
            {
                MoveTo(destinantion - transform.position);
                yield return null;
            }
        }
    }
    public void Shoot(Vector3 destination)
    {
        StartCoroutine(ShootProcessing(destination));
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
