using SDD.Events;
using STUDENT_NAME;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Manager<SpawnManager>
{
    [SerializeField]
    private List<Transform> m_SpawnPoints;
    [SerializeField]
    private GameObject[] m_WasteTypes;
    [SerializeField]
    private int m_NumberOfWaste;

    private List<Transform> m_PossibleSpawnPoints;
    private List<GameObject> m_SpawnedWaste;

    protected override IEnumerator InitCoroutine()
    {
        yield break;
    }

    protected override void Awake()
    {
        base.Awake();
        m_SpawnedWaste = new List<GameObject>();
        m_PossibleSpawnPoints = new List<Transform>();

        m_PossibleSpawnPoints.AddRange(m_SpawnPoints);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    #region Events' subscription
    public override void SubscribeEvents()
    {
        base.SubscribeEvents();

        //Decheterie
        EventManager.Instance.AddListener<ViderDecheterieEvent>(ViderDecheterie);
    }

    public override void UnsubscribeEvents()
    {
        base.UnsubscribeEvents();

        //Score Item
        EventManager.Instance.RemoveListener<ViderDecheterieEvent>(ViderDecheterie);
    }
    #endregion
    
    protected override void GamePlay(GamePlayEvent e)
    {
        Debug.Log("Play");
        SpawnWaste();
    }

    void ViderDecheterie(ViderDecheterieEvent e)
    {
        CleanAllWaste();
        SpawnWaste();
    }

    void SpawnWaste()
    {
        for(var i = 0; i < m_NumberOfWaste; ++i)
        {
            var index = Random.Range(0, m_PossibleSpawnPoints.Count);
            Debug.Log(m_PossibleSpawnPoints.Count);
            // Location
            Transform transformWastePosition = m_PossibleSpawnPoints[index];
            m_PossibleSpawnPoints.RemoveAt(index);
            // Waste Type
            GameObject waste = Instantiate(m_WasteTypes[Random.Range(0, m_WasteTypes.Length)], transformWastePosition);
            // Add
            m_SpawnedWaste.Add(waste);
        }
    }

    void CleanAllWaste()
    {
        foreach(var waste in m_SpawnedWaste)
        {
            Destroy(waste);
        }
        m_PossibleSpawnPoints.AddRange(m_SpawnPoints);
    }
    
}
