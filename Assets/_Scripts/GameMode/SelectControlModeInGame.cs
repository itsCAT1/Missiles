using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectControlModeInGame : MonoBehaviour
{
    public PlaneController planeController;
    public DataManager dataManager;
    public PlaneManager planeManager;

    public GameObject joystick;
    public GameObject buttonArrow;

    public bool firstUpdateJoystick = false;
    public bool firstUpdateMoveFinger = false;

    void Update()
    {
        SetValuePlane();
        SetControlMode();
    }

    public void SetControlMode()
    {
        var planeInGame = planeManager.planes[dataManager.data.indexPlane].GetComponent<PlaneController>();
        if (dataManager.data.indexGameControl == 0)
        {
            firstUpdateMoveFinger = false;
            if (Input.GetMouseButton(0) && !firstUpdateJoystick)
            {
                planeInGame.MovingInputJoystick();
                firstUpdateJoystick = true;
            }
            else if (firstUpdateJoystick)
            {
                planeInGame.MovingInputJoystick();
            }

            buttonArrow.gameObject.SetActive(false);
            joystick.gameObject.SetActive(true);
        }

        else if (dataManager.data.indexGameControl == 1)
        {
            planeInGame.MovingInputButtonArrow();
            buttonArrow.gameObject.SetActive(true);
            joystick.gameObject.SetActive(false);
        }

        else if (dataManager.data.indexGameControl == 2)
        {
            firstUpdateJoystick = false;
            if (Input.GetMouseButton(0) && !firstUpdateMoveFinger)
            {
                planeInGame.MovingInputMoveFinger();
                firstUpdateMoveFinger = true;
            }
            else if (firstUpdateMoveFinger)
            {
                planeInGame.MovingInputMoveFinger();
            }

            buttonArrow.gameObject.SetActive(false);
            joystick.gameObject.SetActive(false);
        }
    }

    public void SetValuePlane()
    {
        var planeInGame = planeManager.planes[dataManager.data.indexPlane].GetComponent<PlaneController>();
        switch (dataManager.data.indexPlane)
        {
            case 0:
                planeInGame.speedMoving = 2;
                planeInGame.speedRotate = 2;
                break;
            case 1:
                planeInGame.speedMoving = 2;
                planeInGame.speedRotate = 2.5f;
                break;
            case 2:
                planeInGame.speedMoving = 2.5f;
                planeInGame.speedRotate = 2;
                break;
            case 3:
                planeInGame.speedMoving = 2.5f;
                planeInGame.speedRotate = 2.5f;
                break;
            case 4:
                planeInGame.speedMoving = 3;
                planeInGame.speedRotate = 2.5f;
                break;
            case 5:
                planeInGame.speedMoving = 2.5f;
                planeInGame.speedRotate = 3;
                break;
            case 6:
                planeInGame.speedMoving = 2;
                planeInGame.speedRotate = 3.5f;
                break;
            case 7:
                planeInGame.speedMoving = 3.5f;
                planeInGame.speedRotate = 2;
                break;
            case 8:
                planeInGame.speedMoving = 3;
                planeInGame.speedRotate = 3;
                break;
            case 9:
                planeInGame.speedMoving = 3;
                planeInGame.speedRotate = 3.5f;
                break;
        }

    }

    public void SelectMode()
    {
        dataManager.data.indexGameControl++;
        if (dataManager.data.indexGameControl > 2)
        {
            dataManager.data.indexGameControl = 0;
        }
    }
}
