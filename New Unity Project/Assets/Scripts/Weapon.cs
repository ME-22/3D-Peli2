﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform throwNode;

    public FireArm fireArm;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }


    public void Shoot()
    {
        if(fireArm != null)
        {
            fireArm.Fire();
        }
        else
        {
            print("Asetta ei ole");
        }
    }

    public void SetFireArm(FireArm NewFireArm)
    {
        fireArm = NewFireArm;
    }
}
