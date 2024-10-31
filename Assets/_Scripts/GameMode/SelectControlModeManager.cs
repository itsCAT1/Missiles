using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using UnityEngine;

public class SelectControlModeManager : MonoBehaviour
{
    public DataManager dataManager;
    public PlaneManager planeManager;

    public GameObject joystick;
    public GameObject buttonArrow;

    public bool firstUpdateJoystick = false;
    public bool firstUpdateMoveFinger = false;

    public StateStartGame stateStartGame;

    void Start()
    {
        var planeInGame = planeManager.planes[dataManager.dataBase.indexPlane].GetComponent<PlaneController>();
        if (!stateStartGame.isStartGame)
        {
            foreach (var plane in planeManager.planes)
            {
                var planeInMenu = plane.GetComponent<PlaneController>();
                planeInMenu.speedMoving = 3;
            }
        }
    }

    private void FixedUpdate()
    {
        if (stateStartGame.isStartGame)
        {
            SetControlMode();
        }
    }


    public void SetControlMode()
    {
        var planeInGame = planeManager.planes[dataManager.dataBase.indexPlane].GetComponent<PlaneController>();
        if (dataManager.dataBase.indexGameControl == 0)
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

        else if (dataManager.dataBase.indexGameControl == 1)
        {
            planeInGame.MovingInputButtonArrow();
            buttonArrow.gameObject.SetActive(true);
            joystick.gameObject.SetActive(false);
        }

        else if (dataManager.dataBase.indexGameControl == 2)
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
        var planeInGame = planeManager.planes[dataManager.dataBase.indexPlane].
            GetComponent<PlaneController>();
        switch (dataManager.dataBase.indexPlane)
        {
            case 0:
                planeInGame.speedMoving = 2;
                planeInGame.speedRotate = 2;
                break;
            case 1:
                planeInGame.speedMoving = 2;
                planeInGame.speedRotate = 2.3f;
                break;
            case 2:
                planeInGame.speedMoving = 2.3f;
                planeInGame.speedRotate = 2;
                break;
            case 3:
                planeInGame.speedMoving = 2.3f;
                planeInGame.speedRotate = 2.3f;
                break;
            case 4:
                planeInGame.speedMoving = 2.6f;
                planeInGame.speedRotate = 2.3f;
                break;
            case 5:
                planeInGame.speedMoving = 2.3f;
                planeInGame.speedRotate = 2.6f;
                break;
            case 6:
                planeInGame.speedMoving = 2;
                planeInGame.speedRotate = 2.9f;
                break;
            case 7:
                planeInGame.speedMoving = 2.9f;
                planeInGame.speedRotate = 2;
                break;
            case 8:
                planeInGame.speedMoving = 2.6f;
                planeInGame.speedRotate = 2.6f;
                break;
            case 9:
                planeInGame.speedMoving = 2.6f;
                planeInGame.speedRotate = 2.9f;
                break;
        }

    }


    public void SelectMode()
    {
        dataManager.dataBase.indexGameControl++;
        if (dataManager.dataBase.indexGameControl > 2)
        {
            dataManager.dataBase.indexGameControl = 0;
        }
    }
}
