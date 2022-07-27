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

    public float orderTime;
    private float orderWaitTimer;

    public AudioSource audioSource;
    public AudioClip[] sounds;

    private void Awake()
    {
        orderWaitTimer = orderTime;
    }

    private void Update()
    {
        orderWaitTimer += Time.deltaTime;
        if (orderWaitTimer > orderTime)
        {
            NewCard();
            orderWaitTimer = 0f;
        }
    }

    public void OnSubmit(GameObject submitFood)
    {
        bool find = false;
        for (var i = 0; i < submitList.Count; i++)
        {
            Cookware cookware = submitFood.GetComponent<Cookware>();
            if (cookware.occupyObj != null)
            {
                string name = cookware.occupyObj.GetComponent<Ingrediant>().IngrediantName;
                Debug.Log($"{name} {submitList[i].name}");
                if (name == submitList[i].name)
                {
                    find = true;
                    var submit = submitList[i].GetComponent<Card>();
                    var isFever = submit.SuccessSubmission();
                    kitchenMgr.GetScore(submit.submitScore, isFever);
                    audioSource.clip = sounds[0];
                    audioSource.Play();
                    Debug.Log(submitList[i].name);
                    break;
                }
            }

        }

        if (!find)
        {
            for (var i = 0; i < submitList.Count; i++)
            {
                submitList[i].GetComponent<Card>().WrongSubmission();
            }
            //audioSource.clip = sounds[1];
            //audioSource.Play();
            kitchenMgr.WrongSubmit();
        }
    }

    private void NewCard()
    {
        if (order.childCount < 5)
        {
            var index = Random.Range(0, cardList.Count);

            var newCard = Instantiate(cardList[index], order);
            //GameObject newCard = PhotonNetwork.Instantiate(cardList[index].name, Vector3.zero, Quaternion.identity);
            newCard.transform.SetParent(order);
            newCard.name = cardList[index].name;
            newCard.transform.localScale = new Vector3(1f, 1f, 1f);
            submitList.Add(newCard);
        }
    }
}
