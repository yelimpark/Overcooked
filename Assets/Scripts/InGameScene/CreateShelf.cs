using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EShelfState
{
    Shelf,
    FireShelf,    
}

public class CreateShelf : MonoBehaviour
{
    public List<CreateShelf> sideShelf = new List<CreateShelf>();

    public GameObject firePrefab;
    public float time = 0f;

    private Frypan fryPantimer;

    private FireHp firehp;

    public EShelfState eShelfState;
    private EShelfState eShelfStateTest;
    public EShelfState CurrentShelfState
    {
        get { return eShelfState; }
        set
        {
            eShelfState = value;
            eShelfStateTest = value;
            switch (eShelfState)
            {
                case EShelfState.Shelf:
                    
                    firePrefab.SetActive(false);
                    break;
                case EShelfState.FireShelf:
                    time = 0f;
                    firePrefab.SetActive(true);
                    break;
            }
        }
    }

    private void Start()
    {
        eShelfState = EShelfState.Shelf;
        eShelfStateTest = eShelfState;
        firePrefab.SetActive(false);

        firehp = GetComponentInChildren<FireHp>(true);
        fryPantimer = GetComponentInChildren<Frypan>(true);
    }


    public void Update()
    {
        if (eShelfState != eShelfStateTest)
        {
            CurrentShelfState = eShelfState;
        }

        switch (eShelfState)
        {
            case EShelfState.Shelf:
                FireOff();
                break;
            case EShelfState.FireShelf:
                FireOn();
                break;
        }
    }
    public void FireOn()
    {
        time += Time.deltaTime;
        // 불 이펙트 on, 상태 FireSelf
        if(time >= 4f)
        {
            time = 0f;
            foreach (var shelf in sideShelf)
            {
                if (shelf.CurrentShelfState != EShelfState.FireShelf)
                {
                    shelf.CurrentShelfState = EShelfState.FireShelf;
                }
            }
        }
        if (firehp.currentTime <= 0)
        {
            eShelfState = EShelfState.Shelf;
            firehp.currentTime = 100f;
        }
    }

    public void FireOff()
    {
        
    }
}
