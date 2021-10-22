using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAgentsManager : MonoBehaviour
{
    [SerializeField] private GameObject agentPrefab;
    [SerializeField] private Transform agentsParrent;
    [SerializeField] private float minTimeToSpawn;
    [SerializeField] private float maxTimeToSpawn;
    [SerializeField] private int maxAgentsOnBoard;

    private float timeToSpawnAgent;
    private float timer = 0;
    private Vector3 spawn;
    private List<Agent> agentsOnBoard;

    void Start()
    {
        timeToSpawnAgent = RandomTimeToSpawn();
        Debug.Log(timeToSpawnAgent);
        agentsOnBoard = new List<Agent>();
        spawn = new Vector3(0, 0, 0);
        SpawnAgentAndAddToList();
    }

    void Update()
    {
        timer = timer + Time.deltaTime;
        if (timer > timeToSpawnAgent)
        {
            if(agentsOnBoard.Count < maxAgentsOnBoard)
            {
                SpawnAgentAndAddToList();
                RandomTimeToSpawn();
            }
        }
    }

    private void SpawnAgentAndAddToList()
    {
        agentsOnBoard.Add(Instantiate(agentPrefab, spawn, Quaternion.identity, agentsParrent).GetComponent<Agent>());
    }

    private float RandomTimeToSpawn()
    {
        timer = 0;
        return Random.Range(minTimeToSpawn, maxTimeToSpawn);
    }
}
