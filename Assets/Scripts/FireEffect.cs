using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireEffect : MonoBehaviour
{
    //ü�¹� 
    public GameObject timer;
    public float spreadTime;
    public float spreadTimer;

    public float creatTimer = 2f;

    public void OnFireExtinguising()
    {
        // ü���� �� ����� ��� �Ҹ��

    }

    private void Update()
    {
        StartCoroutine(fireSpread());
    }

    public IEnumerator fireSpread()
    {      
        //Ư�� �ð��� ������ ��ҿ� ����
        while(true)
        {
            yield return new WaitForSeconds(creatTimer);
            Random.Range(0, -10);
            
        }
    }
}
