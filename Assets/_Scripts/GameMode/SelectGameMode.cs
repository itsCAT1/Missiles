using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class SelectGameMode : MonoBehaviour
{
    public PlaneController planeController;
    public GameObject joystick;
    public GameObject buttonArrow;
    public int indexSelect = 0;
    bool firstUpdateJoystick = false;
    bool firstUpdateMoveFinger = false;
    public bool statePause = false;

    void FixedUpdate()
    {
        if (indexSelect == 0)
        {
            planeController.MovingInMenu();
        }  

        else if (indexSelect == 1)
        {
            if (Input.GetMouseButton(0) && !firstUpdateJoystick)
            {
                planeController.MovingInputJoystickbase();
                firstUpdateJoystick = true;
            }
            else if (firstUpdateJoystick)
            {
                planeController.MovingInputJoystickbase();
            }

            buttonArrow.gameObject.SetActive(false);
            joystick.gameObject.SetActive(true);
        }

        else if (indexSelect == 2)
        {
            planeController.MovingInputButtonArrow();
            buttonArrow.gameObject.SetActive(true);
            joystick.gameObject.SetActive(false);
        }

        else if (indexSelect == 3)
        {
            if (Input.GetMouseButton(0) && !firstUpdateMoveFinger)
            {
                planeController.MovingInputMoveFinger();
                firstUpdateMoveFinger = true;
            }
            else if (firstUpdateMoveFinger)
            {
                planeController.MovingInputMoveFinger();
            }

            buttonArrow.gameObject.SetActive(false);
            joystick.gameObject.SetActive(false);
        }
    }

    public void SelectControlMode()
    {
        indexSelect = 1;
        indexSelect++;
        if(indexSelect > 3)
        {
            indexSelect = 1;
        }
    }

    public void SelectMovingInMenu()
    {
        indexSelect = 0;
    }
}
