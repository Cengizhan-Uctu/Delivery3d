using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerAnimation : MonoBehaviour
{
   
    [SerializeField] Animator anim;
    public void Victory()
    {
        anim.SetInteger("Status",2);
    }
    public void Defeat()
    {
        anim.SetInteger("Status", 1);
    }
}
