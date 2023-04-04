using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbar_UI : MonoBehaviour
{
    [SerializeField] private List<Slot_UI> toolbarSlots = new List<Slot_UI>();

    public GameObject toolBarSlot;
    private Slot_UI selectedSlot;

    private void Start()
    {
        selectedSlot = toolbarSlots[0];
        //SelectSlot(0);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            ToggleToolSlot();
        }
    }
    //function for toggling the toolbar visual
    public void ToggleToolSlot(){
        if(!toolBarSlot.activeSelf){
            toolBarSlot.SetActive(true);
        }
        else{
            toolBarSlot.SetActive(false);
        }
    }
/*
    private void Update()
    {
        CheckAlphaNumericKeys();
    }
    public void SelectSlot(int index)
    {
        if(toolbarSlots.Count == 1)
        {
            selectedSlot = toolbarSlots[index];
            Debug.Log("Selected Slot; " + selectedSlot.name);
        }
    }

    private void CheckAlphaNumericKeys()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectSlot(0);
        }
    }
    */
}