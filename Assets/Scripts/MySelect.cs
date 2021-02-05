﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySelect : MonoBehaviour
{

    public OVRInput.Controller controller;
    private float triggerValue;
    [SerializeField] private bool isInCollider;
    [SerializeField] private bool isSelected;
    private GameObject selectedObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        triggerValue = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger,controller);


        if(isInCollider){
            if(!isSelected && triggerValue >0.95f){
                isSelected = true;
                selectedObj.transform.parent = this.transform;
                Rigidbody rb = selectedObj.GetComponent<Rigidbody>();
                rb.isKinematic = true;
                rb.useGravity = false;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            else if (isSelected && triggerValue < 0.95f){
                isSelected = false;
                selectedObj.transform.parent = null;
                Rigidbody rb = selectedObj.GetComponent<Rigidbody>();
                rb.useGravity = true;
                rb.isKinematic = false;
                rb.velocity = OVRInput.GetLocalControllerVelocity(controller);
                rb.angularVelocity = OVRInput.GetLocalControllerAngularVelocity(controller);
            }
        }
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.name == "RollABall"){
            isInCollider = true;
            selectedObj = other.gameObject;
        }
    }
    void OnTriggerExit(Collider other){
        if(other.gameObject.name=="RollABall"){
            isInCollider = false;
            selectedObj = null;
        }
    }
}
