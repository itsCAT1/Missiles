using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class SelectGameMode : MonoBehaviour
{
    public PlaneController planeController;
    public PlaneManager planeManager;

    public GameObject joystick;
    public GameObject buttonArrow;
    public int indexSelect = 0;
    bool firstUpdateJoystick = false;
    bool firstUpdateMoveFinger = false;

    void FixedUpdate()
    {
        if (indexSelect == 0)
        {
            /*for(int i = 0; i <= planeManager.planes.Count; i++)
            {
                var planeTemp = planeManager.planes[planeManager.currentPlaneIndex].GetComponent<PlaneController>();
                planeTemp.MovingInMenu();
            }*/

            foreach(var plane in planeManager.planes)
            {
                var planeTemp = plane.GetComponent<PlaneController>();
                planeTemp.MovingInMenu();
            }
        }  

        else if (indexSelect == 1)
        {
            firstUpdateMoveFinger = false;
            if (Input.GetMouseButton(0) && !firstUpdateJoystick)
            {
                planeController.MovingInputJoystick();
                firstUpdateJoystick = true;
            }
            else if (firstUpdateJoystick)
            {
                planeController.MovingInputJoystick();
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
            firstUpdateJoystick = false;
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
