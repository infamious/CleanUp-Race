using SDD.Events;
using STUDENT_NAME;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAspi : SimpleGameStateObserver {
    [SerializeField]
    private float m_MaxDistance = 10f;
    [SerializeField]
    private int m_TailleCoffre = 1;
    private int m_ItemsCoffre;

    private void Start()
    {
        m_ItemsCoffre = 0;
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    #region Events' subscription
    public override void SubscribeEvents()
    {
        base.SubscribeEvents();
        EventManager.Instance.AddListener<ViderDecheterieEvent>(CoffreDecharge);
    }

    public override void UnsubscribeEvents()
    {
        base.UnsubscribeEvents();
        EventManager.Instance.RemoveListener<ViderDecheterieEvent>(CoffreDecharge);
    }
    #endregion

    private void Update()
    {
        if (!GameManager.Instance.IsPlaying) return;

        if (Input.GetMouseButtonDown(0) && m_ItemsCoffre < m_TailleCoffre)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, m_MaxDistance))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                if (hit.transform.gameObject.tag == "Waste")
                {
                    ++m_ItemsCoffre;
                    Destroy(hit.transform.gameObject);

                    EventManager.Instance.Raise(new ScoreItemEvent() { eScore = 10 });
                    EventManager.Instance.Raise(new WasteItemEvent() { eWaste = 1 });
                }
                else if (hit.transform.gameObject.tag == "Waste")
                {
                    // Déclencher un label coffre plein
                }
            }
        }
    }

    private void CoffreDecharge(ViderDecheterieEvent e)
    {
        m_ItemsCoffre = 0;
    }
}
