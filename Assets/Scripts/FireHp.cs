using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireHp : MonoBehaviour
{
    public GameObject fireTimeBar;
    
    public float maxTime = 100f;
    public float currentTime;

    private CapsuleCollider capsule;

    private void Awake()
    {
        fireTimeBar = GameObject.Find("Canvas/Slider");
        capsule = GetComponent<CapsuleCollider>();

        currentTime = maxTime;
        //fireHp.gameObject.SetActive(false);
        
    }    

    public void OnFireExtinguising()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        var newpos = UnityEngine.Camera.main.WorldToScreenPoint(transform.position + new Vector3 (0f, 0.8f, 0f));
        fireTimeBar.transform.position = newpos;
    }
    public void TakeDamage(int damage)
    {
        currentTime -= damage;
        //fireHp.value = currentTime / maxTime;
        if(currentTime <= 0)
        {
            Destroy(gameObject);
        }

    }

}
