using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDish : Interactable, ITakeOut
{
    public float timer;
    public Transform spawn;
    public ObjectPoolManager poolManager;
    public bool startTimer = false;

    public List<GameObject> dishes = new List<GameObject>();

    public void Update()
    {
        if (startTimer) 
            timer += Time.deltaTime;

        if (timer > 4f)
        {
            timer = 0f;
            var po = poolManager.Extract("Dish");
            var go = po.gameObject;
            dishes.Add(go);

            Transform transform = go.transform;
            Vector3 dishPos = spawn.position;
            dishPos.y += (transform.lossyScale.y * dishes.Count - transform.lossyScale.y * 0.5f);
            transform.position = dishPos;

            Rigidbody rb = go.GetComponent<Rigidbody>();
            if (rb != null)
                rb.isKinematic = true;

            var colliders = go.GetComponents<Collider>();
            foreach (Collider collider in colliders)
            {
                collider.enabled = false;
            }

            go.transform.rotation = Quaternion.identity;

            startTimer = false;
        }
    }

    public void GenerateDish()
    {
        startTimer = true;
    }

    public bool TakeOut(EquipmentSystem es)
    {
        GameObject takeout = dishes[dishes.Count - 1];
        dishes.Remove(takeout);

        Rigidbody rb = takeout.GetComponent<Rigidbody>();
        if (rb != null)
            rb.isKinematic = false;

        var colliders = takeout.GetComponents<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.enabled = true;
        }

        es.Equip(takeout);

        return true;
    }
}