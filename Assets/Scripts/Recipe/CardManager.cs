using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public List<GameObject> cardList;
    public Transform order;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            NewCard();
        }
    }

    private void OnSubmit(GameObject submittedFood)
    {

    }

    private void NewCard()
    {
        if (order.childCount < 5)
        {
            var index = Random.Range(0, cardList.Count);
            var newCard = Instantiate(cardList[index]);
            newCard.transform.SetParent(order);
            newCard.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
