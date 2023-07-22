using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class SpawnManagerScriptableObject : ScriptableObject
{
    public WeaponInfo[] weaponInfo;
}

public enum Bullet
{
    Arrow,
    Boomerang,
    Hammer
}

[Serializable]
public class WeaponInfo
{
    public Bullet bullet;
    public GameObject prefab;
    public int index;
}