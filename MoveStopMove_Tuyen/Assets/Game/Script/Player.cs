using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    // Start is called before the first frame update
    void Start()
    {
        base.GetNewWeapon();
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
            if(direct != Vector3.zero)
            {
                direct.z = direct.y;
                direct.y = 0;
                MoveTo(direct);
                base.SetStateToMove();
            }
            else
            {
                base.Shoot();
            }
        }
    }
    void MoveTo(Vector3 direct)
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direct, base.speed * Time.deltaTime);
    }
}
