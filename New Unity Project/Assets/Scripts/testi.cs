using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testi : MonoBehaviour, ITakeDamage<float>, IDie, IInteractable
{
    public string objName = "Dummy enemy";
    public float health = 5;

    bool isAlive = true;
    public void Damage(float Damage)
    {
        if (!isAlive)
        {
            return;
        }
        health = Mathf.Max(health - Damage, 0);

        if(health <= 0)
        {
            isAlive = false;
            Die();
        }

        print("otin vahikoa");
    }

    public void Die()
    {
        DestroyObj();
    }


    public void DestroyObj()
    {
        Destroy(gameObject);
    }

    public void TakeDamage()
    {
        print("Au ;-;");
    }

    public void Interact()
    {
        Journar.Instance.Log($"object name is {objName} and it has {health} hp");
    }
}
