using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyWeaponPool : MonoBehaviour
{
    Dictionary<Bullet, Stack<GameObject>> myPool = new();
    [SerializeField] private SpawnManagerScriptableObject objectData;

    public GameObject Pop(Bullet bullet)
    {
        if (!myPool.ContainsKey(bullet))
        {
            myPool.Add(bullet, new Stack<GameObject>());
        }
        if(myPool[bullet].Count == 0)
        {
            GameObject prefab = null;
            for(int i = 0; i < objectData.weaponInfo.Length; ++i)
            {
                if(objectData.weaponInfo[i].bullet == bullet)
                {
                    prefab = objectData.weaponInfo[i].prefab;
                    break;
                }
            }
            for(int i = 0; i < 5; ++i)
            {
                GameObject obj = Instantiate(prefab);
                obj.transform.SetParent(transform);
                obj.SetActive(false);
                myPool[bullet].Push(obj);
            }
        }
        GameObject tmp = myPool[bullet].Pop();
        tmp.transform.SetParent(null);
        tmp.SetActive(true);
        return tmp;
    }
    public void Push(GameObject obj, Bullet bullet)
    {
        if (!myPool.ContainsKey(bullet))
        {
            myPool.Add(bullet, new Stack<GameObject>());
        }
        obj.transform.SetParent(transform);
        obj.SetActive(false);
        myPool[bullet].Push(obj);
    }
}
