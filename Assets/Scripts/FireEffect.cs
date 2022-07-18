using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireEffect : MonoBehaviour
{
    //체력바 
    public GameObject timer;
    public float spreadTime;
    public float spreadTimer;

    public float creatTimer = 2f;

    public void OnFireExtinguising()
    {
        // 체력이 다 닳았을 경우 소멸됨

    }

    private void Update()
    {
        StartCoroutine(fireSpread());
    }

    public IEnumerator fireSpread()
    {      
        //특정 시간에 랜덤한 장소에 생성
        while(true)
        {
            yield return new WaitForSeconds(creatTimer);
            Random.Range(0, -10);
            
        }
    }
}
