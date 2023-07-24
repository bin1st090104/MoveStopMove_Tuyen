using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotManager : MonoBehaviour
{
    [SerializeField] private GameObject botPrefab;
    [SerializeField] private int botCount;
    private List<Character> botList = new();
    private Character player;
    private void Start()
    {
        for(int i = 0; i < botCount; ++i)
        {
            GameObject bot = Instantiate(botPrefab);
            botList.Add(bot.GetComponent<Character>());
            bot.transform.position = new Vector3(Random.Range(-25, 25), 2, Random.Range(-25, 25));
        }
    }
    private bool Minimize(ref float x, float y)
    {
        if (y < x)
        {
            x = y;
            return true;
        }
        return false;
    }
    public Character GetNearestTarget(Vector3 currentPosition)
    {
        Character curTarget = null;
        float curDistance = Mathf.Infinity;
        if(player != null)
        {
            curDistance = Vector3.Distance(currentPosition, player.transform.position);
            curTarget = player;
        }
        for(int i = 0; i < botList.Count; ++i)
        {
            Character bot = botList[i];
            if(bot.gameObject.activeSelf == false || Vector3.Distance(bot.transform.position, currentPosition) < 1e-3)
            {
                continue;
            }
            if(Minimize(curDistance, Vector3.Distance(bot.transform.position, currentPosition)){

            }
        }
        return curTarget;
    }
    private void Update()
    {
        if(player == null)
        {
            player = FindObjectOfType<Player>();
        }
    }
}
