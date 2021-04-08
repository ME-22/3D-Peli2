using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform throwNode;

    public float throwForce = 10f;

    public GameObject throwObjPrefab;

    public FireArm fireArm;

    private Camera FPSCamera;

    public Transform weaponNode;

    public List<Transform> firearms = new List<Transform>();

    public int currentWeaponIndex = 0;


    // Start is called before the first frame update
    
    void Start()
    {
        FPSCamera = Camera.main;

        foreach(Transform child in weaponNode)
        {
            if (child.GetComponent<FireArm>())
            {
                firearms.Add(child);
            }
        }

        UpdateCurrentWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Throw();
        }


        if (Input.GetButtonDown("Fire2"))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeNextWeapon(1);
        }

    }

    private void Throw()
    {
        GameObject obj = Instantiate(throwObjPrefab, throwNode.position, Quaternion.identity);
        obj.GetComponent<Rigidbody>().AddForce(FPSCamera.transform.forward * throwForce);
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

    public void ChangeNextWeapon(int nextIndex) 
    {
        currentWeaponIndex += nextIndex;

        if(currentWeaponIndex > firearms.Count - 1) 
        {
            currentWeaponIndex = 0;
        }

        UpdateCurrentWeapon();
    }

    public void UpdateCurrentWeapon()
    {
        for(int i = 0; i < firearms.Count; i++)
        {
            if (currentWeaponIndex != i)
            {
                firearms[i].gameObject.SetActive(false);
            }
            else 
            {
                firearms[i].gameObject.SetActive(true);
                fireArm = firearms[i].GetComponent<FireArm>();
            }
        }
    }
}
