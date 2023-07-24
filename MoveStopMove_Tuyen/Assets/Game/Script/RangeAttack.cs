using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{
    [SerializeField] private Character myCharacter;

    private LinkedList<Character> InRangeList = new();

    public void SetSize(float size)
    {
        transform.localScale = new Vector3(size, size, size);
    }

    public Character GetEarliestCharacter() {
        foreach(Character value in InRangeList)
        {
            Debug.Log("in range list:" + value);
        }
        LinkedListNode<Character> ans = null;
        while(ans == null && InRangeList.Count > 0)
        {
            ans = InRangeList.First;
            Debug.Log("ans = " + ans);
            if(ans.Value.gameObject.activeSelf == false)
            {
                Debug.Log("Removed");
                InRangeList.RemoveFirst();
            }
        }
        if(ans == null)
        {
            return null;
        }
        return ans.Value;
    }
    private void Update()
    {
        //Debug.Log(GetEarliestCharacter());
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Body")
        {
            Character otherCharacter = other.transform.GetComponentInParent<Character>();
            if(otherCharacter == myCharacter)
            {
                return;
            }
            Debug.Log(myCharacter.name + " ADD " + otherCharacter.name);
            InRangeList.AddLast(otherCharacter);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Body")
        {
            Character otherCharacter = other.transform.GetComponentInParent<Character>();
            if (otherCharacter == myCharacter)
            {
                return;
            }
            Debug.Log(myCharacter.name + " REV " + otherCharacter.name);
            InRangeList.Remove(otherCharacter);
        }
    }
}
