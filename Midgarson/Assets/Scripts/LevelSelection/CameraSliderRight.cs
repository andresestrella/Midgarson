using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSliderRight : MonoBehaviour
{
    private void OnMouseDown() {
        CameraBehavior.slideLeft = false;
        CameraBehavior.isSliding = true;
    }
}
