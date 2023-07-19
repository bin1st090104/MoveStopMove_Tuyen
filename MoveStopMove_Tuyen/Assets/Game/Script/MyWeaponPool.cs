using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyWeaponPool : MonoBehaviour
{
    [SerializeField] GameObject weapon;
    private Stack<GameObject> pool = new Stack<GameObject>();
    public GameObject Pop()
    {
        GameObject obj;
        if (pool.Count == 0)
        {
            for(int i = 0; i < 10; ++i)
            {
                obj = Object.Instantiate(weapon);
                obj.SetActive(false);
                pool.Push(obj);
            }
        }
        obj = pool.Pop();
        obj.SetActive(true);
        return obj;  
    }
    public void Push(GameObject obj)
    {
        obj.SetActive(false);
        pool.Push(obj);
    }
}
