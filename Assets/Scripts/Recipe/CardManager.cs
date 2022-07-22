using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CardManager : MonoBehaviour
{
    public KitchenManager kitchenMgr;
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
                var submit = submitList[i].GetComponent<Card>();
                var isFever = submit.SuccessSubmission();
                kitchenMgr.GetScore(submit.submitScore, isFever);
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
            kitchenMgr.WrongSubmit();
        }
    }

    private void NewCard()
    {
        if (order.childCount < 5)
        {
            var index = Random.Range(0, cardList.Count);

            //var newCard = Instantiate(cardList[index], order);
            GameObject newCard = PhotonNetwork.Instantiate(cardList[index].name, Vector3.zero, Quaternion.identity);
            newCard.transform.SetParent(order);
            newCard.name = cardList[index].name;
            newCard.transform.localScale = new Vector3(1f, 1f, 1f);
            submitList.Add(newCard);
        }
    }
}
