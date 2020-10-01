using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrenchBehaviour : MonoBehaviour
{
    private bool Attack;
    public bool CanHit = false;
    public GameObject target;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack = true;
            SwingWrench();
            Attack = false;
        }
    }
    public void SwingWrench()
    {
        //insert animation thingy here xd
        if (CanHit)
        {
            target.GetComponent<EnemyBehaviour>().TakeDamage();
        }
    }
}
