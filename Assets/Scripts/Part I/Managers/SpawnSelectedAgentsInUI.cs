using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSelectedAgentsInUI : MonoBehaviour
{
    [SerializeField] private BoxSelection boxSelection;
    [SerializeField] private GameObject agentsStatusPrefab;
    [SerializeField] private Transform contentPanel;

    public List<AgentStatus> spawnedViev;
    public List<Agent> agentsSelectedList;

    private Vector2 spawnPlace;
    private int selectedCount = 0;

    void Start()
    {
        spawnedViev = new List<AgentStatus>();
        agentsSelectedList = new List<Agent>();
    }

    void Update()
    {
        if(boxSelection.GetSelectedList() != null)
        {
            agentsSelectedList = boxSelection.GetSelectedList();
            ShowAgentsStatus();
        }
        CheckIfAgentWasDestroyed();
        UpdateView();
    }

    private void ShowAgentsStatus()
    {
        if(agentsSelectedList.Count > 0)
        {
            if(agentsSelectedList.Count != selectedCount || boxSelection.wasChanged)
            {
                ResetSelectedView();
            }
        }else
        {
            DeleteSelectedAgentsView();
        }
    }

    private void UpdateView()
    {
        if(spawnedViev.Count != agentsSelectedList.Count)
        {
            ResetSelectedView();
        }
    }

    private void ResetSelectedView()
    {
        DeleteSelectedAgentsView();
        foreach (Agent agent in agentsSelectedList)
        {
            if (agent != null)
            {
                SpawnAgentViewUI(agent.name, agent.GetLifePoints());
            }
            else
            {
                agentsSelectedList.Remove(agent);
                boxSelection.wasChanged = true;
                break;
            }
        }
        selectedCount = agentsSelectedList.Count;
        boxSelection.wasChanged = false;
    }

    private void DeleteSelectedAgentsView()
    {
        foreach(AgentStatus agentStatus in spawnedViev)
        {
            Destroy(agentStatus.agentViewObject);
        }
        spawnedViev.Clear();
    }

    private void CheckIfAgentWasDestroyed()
    {
        foreach (Agent agent in agentsSelectedList)
        {
            if(agent == null)
            {
                ResetSelectedList();
                break;
            }
        }
       
    }

    private void ResetSelectedList()
    {
        DeleteSelectedAgentsView();
        agentsSelectedList.RemoveAll(selected => selected == null);
        boxSelection.wasChanged = true;
    }

    private void SpawnAgentViewUI(string agentName, int lifePoints)
    {
        GameObject agentStatusPrefab;
        agentStatusPrefab = Instantiate(agentsStatusPrefab, spawnPlace, Quaternion.identity, contentPanel);
        agentStatusPrefab.transform.localScale = new Vector3(1, 1, 1);
        AgentStatus agent = agentStatusPrefab.GetComponent<AgentStatus>();
        agent.ChangeStaus(agentName, lifePoints.ToString());

       spawnedViev.Add(agent);
    }

}
