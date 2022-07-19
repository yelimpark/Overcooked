using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireHp : MonoBehaviour
{
    //Ã¼·Â¹Ù 
    //public Slider fireHp;
    public GameObject fireTimeBar;
    public float Yoffset = 20f;
    
    public float maxTime = 100f;
    public float currentTime;

    private CapsuleCollider capsule;

    private void Awake()
    {
        //fireHp = GetComponent<Slider>();
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
        //fireBarPrefab.transform.position = transform.position;
        var newpos = UnityEngine.Camera.main.WorldToScreenPoint(transform.position);
        //newpos.y += Yoffset;
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
