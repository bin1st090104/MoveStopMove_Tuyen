using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private Bullet originalBullet;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(name + " of " + (transform.parent == null ? "null" : transform.parent.name) + "  " + other.name + " of " + (other.gameObject.transform.parent == null ? "null" : other.gameObject.transform.parent.name));
    }

    void Start()
    {
        base.curBullet = originalBullet;
        base.rangeAttack.SetSize(base.originalRangeAttackSize);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private Vector3 rootMousePosition;
    void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rootMousePosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 direct = Input.mousePosition - rootMousePosition;
            if (direct != Vector3.zero)
            {
                direct.z = direct.y;
                direct.y = 0f;
                MoveTo(direct);
                base.SetStateToMove();
            }
        }
        else
        {
            base.Shoot();
        }
    }
    void MoveTo(Vector3 direct)
    {
        transform.LookAt(direct + Vector3.up * transform.position.y);
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direct, base.speed * Time.deltaTime);
    }
}
