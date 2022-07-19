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

    public void OnSubmit(GameObject submitFood)
    {
        bool find = false;
        for (var i = 0; i < submitList.Count; i++)
        {
            if (submitFood.transform.name == submitList[i].name)
            {
                find = true;
                submitList[i].GetComponent<Card>().SuccessSubmission();
                Debug.Log(submitList[i].name);
                break;
            }
        }

        if (!find)
        {
            for (var i = 0; i < submitList.Count; i++)
            {
                submitList[i].GetComponent<Card>().WrongSubmission();
            }
        }
    }

    private void NewCard()
    {
        if (order.childCount < 5)
        {
            var index = Random.Range(0, cardList.Count);
            var newCard = Instantiate(cardList[index], order);
            newCard.name = cardList[index].name;
            newCard.transform.localScale = new Vector3(1f, 1f, 1f);
            submitList.Add(newCard);
        }
    }
}
