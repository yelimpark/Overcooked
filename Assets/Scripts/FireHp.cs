using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireHp : MonoBehaviour
{
    public Image fireBg;
    public Slider fireHp;
    
    public float maxTime = 100f;
    public float currentTime;
    private float curHp;

    private CapsuleCollider capsule;

    private void Awake()
    {
        capsule = GetComponent<CapsuleCollider>();
        currentTime = maxTime;
        fireHp.gameObject.SetActive(false);
        fireBg.gameObject.SetActive(false);

    }

    private void Start()
    {
        
    }
    private void LateUpdate()
    {

        
        fireHp.transform.position = transform.position + new Vector3(0f, 0.8f, 0f);
        fireHp.transform.LookAt(transform.position + UnityEngine.Camera.main.transform.rotation * Vector3.back, UnityEngine.Camera.main.transform.rotation * Vector3.up);

        var newpos = UnityEngine.Camera.main.WorldToScreenPoint(transform.position);
        fireBg.transform.position = newpos;

        //fireBg.transform.position = transform.position + new Vector3(0f, 0.8f, 0f);
        //fireBg.transform.LookAt(transform.position + UnityEngine.Camera.main.transform.rotation * Vector3.back, UnityEngine.Camera.main.transform.rotation * Vector3.up);
    }

    public void OnFireExtinguising()
    {
        Destroy(gameObject);
    }
    public void TakeDamage(int damage)
    {
        currentTime -= damage;
        fireHp.gameObject.SetActive(true);
        fireBg.gameObject.SetActive(true);
        curHp = currentTime / maxTime;
        fireHp.value = Mathf.Lerp(fireHp.value, curHp, Time.deltaTime * 10);

        if( currentTime <= 0 )
        {
            fireHp.gameObject.SetActive(false);
            fireBg.gameObject.SetActive(false);
        }
    }

}
