using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSelection : MonoBehaviour
{
    SelectedDictionary selectedTable;
    RaycastHit hit;
    bool dragSelect;


    MeshCollider selectedBox;
    Vector3 p1;
    Vector3 p2;

    //Vector2 corners[];

    //Vector2 verts[];

    void Start()
    {
        selectedTable = GetComponent<SelectedDictionary>();
        dragSelect = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            p1 = Input.mousePosition;
        }

        if(Input.GetMouseButton(0))
        {
            if((p1 - Input.mousePosition).magnitude > 40)
            {
                dragSelect = true;
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            if(dragSelect == false)
            {
                Ray ray = Camera.main.ScreenPointToRay(p1);

                if(Physics.Raycast(ray, out hit, 5000.0f))
                {
                    if(Input.GetKey(KeyCode.LeftShift))
                    {
                        selectedTable.AddSelected(hit.transform.gameObject);
                    }else
                    {
                        selectedTable.DeselectAll();
                        selectedTable.AddSelected(hit.transform.gameObject);
                    }
                }else
                {
                    if(Input.GetKey(KeyCode.LeftShift))
                    {

                    }else
                    {
                        selectedTable.DeselectAll();
                    }
                }
            }
        }
    }
}
