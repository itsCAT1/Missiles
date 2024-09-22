using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonArrowController : MonoBehaviour
{
    public int rotateAmount = 0;

    public void SelectArrowLeft()
    {
        rotateAmount = -1;
    }

    public void DeselectArrowLeft()
    {
        rotateAmount = 0;
    }

    public void SelectArrowRight()
    {
        rotateAmount = 1;
    }

    public void DeselectArrowRight()
    {
        rotateAmount = 0;
    }
}
