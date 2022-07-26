using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDish : MonoBehaviour
{
    //음식이 계산대에 들어갔을때 시간이 지나면 해당 위치에 생성 할 수 있도록

    public float timer;

    private CreateIngredient createObject;


    private void Start()
    {
        createObject = GetComponent<CreateIngredient>();
    }

    public void GenerateDish()
    {
        timer += Time.deltaTime;
        if (timer > 4f)
        {
            createObject.Create();
        }
    }
}