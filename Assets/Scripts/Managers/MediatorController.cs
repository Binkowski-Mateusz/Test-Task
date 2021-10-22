using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediatorController : MonoBehaviour
{
    public static MediatorController Instance { get; set; }
    public SpawnAgentsManager spawnAgentsManager;

    public void RemoveAgent(Agent agent)
    {
        spawnAgentsManager.RemoveAgentFromList(agent);
    }
}
