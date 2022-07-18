using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public List<GameObject> cardList;
    public List<GameObject> submitList;
    public Transform order;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            NewCard();
        }
    }

    private void OnSubmit(GameObject submitFood)
    {

    }

    private void NewCard()
    {
        if (order.childCount < 5)
        {
            var index = Random.Range(0, cardList.Count);
            var newCard = Instantiate(cardList[index], order);
            newCard.transform.localScale = new Vector3(1f, 1f, 1f);
            submitList.Add(newCard);
        }
    }
}
