using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    private Vector3 currentPos;
    private float moveStep;

    void Start()
    {
        if (virtualCamera == null)
        {
            virtualCamera = GetComponent<CinemachineVirtualCamera>();
        }

        currentPos = virtualCamera.transform.localPosition;
        moveStep = 18; // should be Screen.width;
    }


    public void MoveToLeft()
    {
        //Debug.Log("moving to the left from " + virtualCamera.transform.localPosition);
        currentPos.x -= moveStep;
        virtualCamera.ForceCameraPosition(new Vector3(currentPos.x, currentPos.y, currentPos.z), Quaternion.Euler(0, 0, 0));
        //Debug.Log("now its " + virtualCamera.transform.localPosition);
    }

    public void MoveToRight()
    {
        //Debug.Log("moving to the right from " + virtualCamera.transform.localPosition);
        currentPos.x += moveStep;
        virtualCamera.ForceCameraPosition(new Vector3(currentPos.x, currentPos.y, currentPos.z), Quaternion.Euler(0, 0, 0));
        //Debug.Log("now its " + virtualCamera.transform.localPosition);
    }


    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
}
