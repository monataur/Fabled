using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy (Map)", menuName = "Enemy (Map)")]
public class MapEnemy : ScriptableObject
{
    public int enemyCount;
    public Enemy enemy1;
    public Enemy enemy2;
    public Enemy enemy3;
    public Enemy enemy4;
    public string flavor;
    public Track track;
}
