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
    public int indexSelectMode = 0;
    bool firstUpdateJoystick = false;
    bool firstUpdateMoveFinger = false;

    void FixedUpdate()
    {
        if (indexSelectMode == 0)
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

        else if (indexSelectMode == 1)
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

        else if (indexSelectMode == 2)
        {
            planeController.MovingInputButtonArrow();
            buttonArrow.gameObject.SetActive(true);
            joystick.gameObject.SetActive(false);
        }

        else if (indexSelectMode == 3)
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
        StartCoroutine(StateStartGame());
        indexSelectMode++;
        if (indexSelectMode > 3)
        {
            indexSelectMode = 1;
        }
    }

    IEnumerator StateStartGame()
    {
        for (int i = 0; i <= planeManager.planes.Count; i++)
        {
            var planeTemp = planeManager.planes[planeManager.currentPlaneIndex].GetComponent<PlaneController>();
            planeTemp.rigid2D.angularVelocity = 185;
        }
        yield return new WaitForSeconds(1);
        for (int i = 0; i <= planeManager.planes.Count; i++)
        {
            var planeTemp = planeManager.planes[planeManager.currentPlaneIndex].GetComponent<PlaneController>();
            planeTemp.rigid2D.angularVelocity = 0;
        }
    }
}
