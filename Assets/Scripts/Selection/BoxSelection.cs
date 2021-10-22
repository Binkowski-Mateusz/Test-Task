using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSelection : MonoBehaviour
{
    [SerializeField] Collider[] selections;
    [SerializeField] Box box;
    private Vector3 startPosition, dragPosition;
    private Camera cam;
    private Ray ray;
    private List<Agent> agentsSelected;

    void Start()
    {
        cam = Camera.main;
        agentsSelected = new List<Agent>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            DoSelectedBoxFromMouse();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            UnSelectAgents();
            AddSelectedAgentsToList();
        }
    }

    private void DoSelectedBoxFromMouse()
    {
        RaycastHit hit;
        ray = cam.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(ray, out hit, 100f);

        if (Input.GetMouseButtonDown(0))
        {
            startPosition = hit.point;
            box.baseMin = startPosition;
        }

        dragPosition = hit.point;
        box.baseMax = dragPosition;
    }

    private void AddSelectedAgentsToList()
    {
        selections = Physics.OverlapBox(box.Center, box.Extens, Quaternion.identity);
        foreach (var obj in selections)
        {
            Agent agent = obj.GetComponent<Agent>();

            if (agent != null)
            {
                agent.Selected(true);
                agentsSelected.Add(agent);
            }
        }
    }

    private void UnSelectAgents()
    {
        if(agentsSelected.Count > 0)
        {
            foreach(var agent in agentsSelected)
            {
                agent.Selected(false);
            }
            agentsSelected.Clear();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireCube(box.Center, box.Size);
    }
}

