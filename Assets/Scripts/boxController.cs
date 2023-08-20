using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxController : MonoBehaviour
{
    [SerializeField] private heroStcakController heroStackController;
    private Vector3 direction = Vector3.back;
    private bool isStack = false;
    private RaycastHit hit;


    private void Start()
    {
        heroStackController = GameObject.FindObjectOfType<heroStcakController>();
    }


    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, direction, out hit, 1f))
        {
            if (!isStack)
            {
                isStack = !isStack;
                heroStackController.IncreaseNewBlock(gameObject);
                SetDirection();
            }

            if (hit.transform.name == "ObstacleCube")
            {
                heroStackController.DecreaseBlock(gameObject);
            }
        }
    }


    private void SetDirection()
    {
        direction = Vector3.forward;
    }
}

