using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    public new string name;
    public string description;
    public Sprite sprite;
    public RuntimeAnimatorController animator;
    public Enums.Element element;
    public Transform shadow;
    public Enemy enemy;

    public void Update()
    {
        name = enemy.name;
        description = enemy.description;
        sprite = enemy.sprite;
        gameObject.GetComponent<Animator>().runtimeAnimatorController = enemy.animator;
        element = enemy.element;
    }
}
