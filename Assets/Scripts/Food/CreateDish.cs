using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDish : MonoBehaviour
{
    //������ ���뿡 ������ �ð��� ������ �ش� ��ġ�� ���� �� �� �ֵ���

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