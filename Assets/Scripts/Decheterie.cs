using SDD.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decheterie : SimpleGameStateObserver
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.CompareTag("Player"))
        {
            EventManager.Instance.Raise(new ViderDecheterieEvent());
        }
    }
}
