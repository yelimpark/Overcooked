using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireHp : MonoBehaviour
{
    //public GameObject fireTimeBar;
    public GameObject fire;
    
    public float maxTime = 100f;
    public float currentTime;

    private CapsuleCollider capsule;

    private void Awake()
    {
        capsule = GetComponent<CapsuleCollider>();

        currentTime = maxTime;
        fire.SetActive(false);

        //var newpos = UnityEngine.Camera.main.WorldToScreenPoint(transform.position + new Vector3(0f, 0.8f, 0f));
        //fire.transform.position = newpos;
        fire.transform.position = transform.position + new Vector3(0f, 0.8f, 0f);
        fire.transform.LookAt(transform.position + UnityEngine.Camera.main.transform.rotation * Vector3.back, UnityEngine.Camera.main.transform.rotation * Vector3.down);
    }

    public void OnFireExtinguising()
    {
        Destroy(gameObject);
    }
    public void TakeDamage(int damage)
    {
        currentTime -= damage;       
        fire.SetActive(true);
    }

}
