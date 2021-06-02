using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Pointer : BaseInput
{
    public GameManager GameManager;

    public OVRInput.Button clickButton = OVRInput.Button.PrimaryIndexTrigger;
    public OVRInput.Controller controller = OVRInput.Controller.All;

    public void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "StartButton")
        {
            other.GetComponent<PointerColorChange>().EnterChange();

            if (OVRInput.GetDown(clickButton, controller))
            {
                GameManager.StartGame();
            }
        }

        else if (other.transform.tag == "TutorialButton")
        {
            other.GetComponent<PointerColorChange>().EnterChange();

            if (OVRInput.Get(clickButton, controller))
            {
                GameManager.StartTutorial();
            }
        }

        else if (other.transform.tag == "QuitButton")
        {
            other.GetComponent<PointerColorChange>().EnterChange();

            if (OVRInput.Get(clickButton, controller))
            {
                GameManager.Close();
            }
        }

        else if (other.transform.tag == "MenuButton")
        {
            other.GetComponent<PointerColorChange>().EnterChange();

            if (OVRInput.Get(clickButton, controller))
            {
                GameManager.Menu();
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "StartButton")
        {
            other.GetComponent<PointerColorChange>().ExitChange();
        }

        if (other.transform.tag == "TutroialButton")
        {
            other.GetComponent<PointerColorChange>().ExitChange();
        }

        if (other.transform.tag == "QuitButton")
        {
            other.GetComponent<PointerColorChange>().ExitChange();
        }

        if (other.transform.tag == "MenuButton")
        {
            other.GetComponent<PointerColorChange>().ExitChange();
        }

    }













}
