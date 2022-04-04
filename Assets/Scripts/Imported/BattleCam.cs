using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCam : MonoBehaviour
{
    public Camera mainCam;
    public Transform mainCamTrans;
    public Transform party1Trans;
    public Transform party2Trans;
    public Transform party3Trans;
    public Transform party4Trans;
    public Transform enemy1Trans;
    public Transform enemy2Trans;
    public Transform enemy3Trans;
    public Transform enemy4Trans;
    public Vector3 targetPosition;
    public float smoothTime = 0.1f;
    private Vector3 velocity = Vector3.zero;
    private float zeroVelo = 0.0f;
    public float camSize = 1;
    public GameObject battleObject;
    public enum TargetStatus {LookParty1, LookParty2, LookParty3, LookParty4, LookEnemy1, LookEnemy2, LookEnemy3, LookEnemy4, LookInbetween}
    public enum ZoomSize {Default, LowZoomIn, MediumZoomIn, HighZoomIn, LowZoomOut, MediumZoomOut, HighZoomOut}
    public TargetStatus TStatus = TargetStatus.LookInbetween;
    public ZoomSize zoomStatus = ZoomSize.Default;
    public GameObject partyobj;
    public float offsetY = 0.0f;
    public float offsetX = 0.0f;
    public Vector3 newPos;
    void Update()
    {
        var status = partyobj.GetComponent<Party>().status;

        newPos = new Vector3(TargetSDamp().x + offsetX, TargetSDamp().y + offsetY, TargetSDamp().z);
        switch (status)
        {
            case Enums.PartyStatus.Map:
                TStatus = TargetStatus.LookParty1;
                zoomStatus = ZoomSize.Default;
                offsetX = 0f;
                offsetY = 0f;
                transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, smoothTime);
                mainCam.orthographicSize = Mathf.SmoothDamp(mainCam.orthographicSize, CamSize(), ref zeroVelo, smoothTime);
                break;

            case Enums.PartyStatus.Battle:
                offsetX = 0.85f;
                offsetY = battleObject.GetComponent<TurnManager>().CamYOffset();
                transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, smoothTime);
                mainCam.orthographicSize = Mathf.SmoothDamp(mainCam.orthographicSize, CamSize(), ref zeroVelo, smoothTime);
                break;

            case Enums.PartyStatus.Cutscene:
                break;
        }
    }

    float CamSize()
    {
        switch (zoomStatus)
        {
            case ZoomSize.Default:
                return 1f;

            case ZoomSize.LowZoomIn:
                return 0.75f;

            case ZoomSize.MediumZoomIn:
                return 0.5f;

            case ZoomSize.HighZoomIn:
                return 0.25f;

            case ZoomSize.LowZoomOut:
                return 1.25f;

            case ZoomSize.MediumZoomOut:
                return 1.5f;

            case ZoomSize.HighZoomOut:
                return 1.75f;

            default:
                return 1f;
        }
    }

    Vector3 TargetSDamp()
    {
        switch(TStatus)
        {
            case TargetStatus.LookParty1:
                return new Vector3(party1Trans.position.x, party1Trans.position.y, -10);

            case TargetStatus.LookParty2:
                return new Vector3(party2Trans.position.x, party2Trans.position.y, -10);

            case TargetStatus.LookParty3:
                return new Vector3(party3Trans.position.x, party3Trans.position.y, -10);

            case TargetStatus.LookParty4:
                return new Vector3(party4Trans.position.x, party4Trans.position.y, -10);

            case TargetStatus.LookEnemy1:
                return new Vector3(enemy1Trans.position.x, enemy1Trans.position.y, -10);

            case TargetStatus.LookEnemy2:
                return new Vector3(enemy2Trans.position.x, enemy2Trans.position.y, -10);

            case TargetStatus.LookEnemy3:
                return new Vector3(enemy3Trans.position.x, enemy3Trans.position.y, -10);

            case TargetStatus.LookEnemy4:
                return new Vector3(enemy4Trans.position.x, enemy4Trans.position.y, -10);

            case TargetStatus.LookInbetween:
                return new Vector3(0f, -0.2f, -10f);

            default:
                Debug.Log("camera dun goofed");
                return new Vector3(0, 0, 0);
        }
    }
}
