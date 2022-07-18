using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireHp : MonoBehaviour
{
    //체력바 
    public GameObject fireBarPrefab;
    public float maxFire = 100f;
    public float currentFire;

    private CapsuleCollider capsule;

    private void Awake()
    {
        capsule = GetComponent<CapsuleCollider>();
        currentFire = maxFire;
    }

    public void TakeDamage(int amount)
    {
        // 체력이 다 닳았을 경우 소멸됨
        currentFire -= amount;
        if(currentFire <= 0)
        {
            OnFireExtinguising();
        }
    }

    public void OnFireExtinguising()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
       
    }

}
