using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/*.............................................................................*
 |~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~|
 |                                INSTRUCTIONS                                 |
 |~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~|
 |'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''|
 | This script has INCOMPLETE code. Use [CTRL][F] to look for the [TODO] tags. |
 *'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''*/

public class GestureManager : MonoBehaviour {

    /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
     *                               PROPERTIES                                *
     * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

    public static GestureManager Instance;

    private Touch[] _trackedFingers = new Touch[2];
    private float _gestureTime = 0;
    private Vector2 _startPoint = Vector2.zero;
    private Vector2 _endPoint = Vector2.zero;

    [SerializeField]
    private GraphicRaycaster _graphicRaycaster;

    [SerializeField]
    private EventSystem _eventSystem;

    [SerializeField]
    private TapProperty _tapProperty;
    public EventHandler<TapEventArgs> OnTap;

    [SerializeField]
    private SpreadProperty _spreadProperty;
    public EventHandler<SpreadEventArgs> OnSpread;

    [SerializeField]
    private RotateProperty _rotateProperty;
    public EventHandler<RotateEventArgs> OnRotate;

    /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
     *                             GENERAL METHODS                             *
     * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

    private void CheckSingleFingerInput() {
        this._trackedFingers[0] = Input.GetTouch(0);

        switch(this._trackedFingers[0].phase) {
            case TouchPhase.Began:
                this._startPoint = this._trackedFingers[0].position;
                this._gestureTime = 0;
                break;

            case TouchPhase.Ended:
                this._endPoint = this._trackedFingers[0].position;
                this.CheckTap();
                break;

            default:
                this._gestureTime += Time.deltaTime;
                break;
        }
    }

    private void CheckTap() {
        if(this._gestureTime <= this._tapProperty.Time &&
           Vector2.Distance(this._startPoint, this._endPoint) <= (Screen.dpi * this._tapProperty.MaxDistance)) {
            this.FireTapEvent();
        }
    }

    private void FireTapEvent() {
        GameObject hitObject = this.GetHitGraphic(this._startPoint);
        if(hitObject == null)
            hitObject = this.GetHitObject(this._startPoint);

        TapEventArgs args = new TapEventArgs();

        if(hitObject != null) {
            ITappable handler = hitObject.GetComponent<ITappable>();
            if(handler != null) {
                handler.OnTap(args);
            }
        }
    }

    private void CheckDualFingerInput() {
        this._trackedFingers[0] = Input.GetTouch(0);
        this._trackedFingers[1] = Input.GetTouch(1);

        switch(this._trackedFingers[0].phase, this._trackedFingers[1].phase) {
            case (TouchPhase.Moved, _):
            case (_, TouchPhase.Moved):
                this.CheckSpread();
                this.CheckRotate();
                break;
        }
    }


    private void CheckSpread() {
        Vector2 previousPoint0 = this.GetPreviousPoint(this._trackedFingers[0]);
        Vector2 previousPoint1 = this.GetPreviousPoint(this._trackedFingers[1]);

        float previousDistance = Vector2.Distance(previousPoint0, previousPoint1);
        float currentDistance = Vector2.Distance(this._trackedFingers[0].position, this._trackedFingers[1].position);
        
        if(Mathf.Abs(currentDistance - previousDistance) >=
           (this._spreadProperty.MinDistanceChange)) {
            this.FireSpreadEvent(currentDistance - previousDistance);
        }
    }

    private void FireSpreadEvent(float distanceDelta) {
        Vector2 midPoint = this.GetMidPoint(this._trackedFingers[0].position, this._trackedFingers[1].position);
        GameObject hitObject = this.GetHitObject(midPoint);
        SpreadEventArgs args = new SpreadEventArgs();

        if(this.OnSpread != null) {
            this.OnSpread(this, args);
        }

        if(hitObject != null) {
            ISpreadable handler = hitObject.GetComponent<ISpreadable>();
            if(handler != null) {
                handler.OnSpread(args);
            }
        }
    }

    private void CheckRotate() {

        /* * * * * * [TODO][X] * * * * * *
         |~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~|
         | Fill this script up with the  |
         | necessary logic. Refer to the |
         | document for more details.    |
         |~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~|
         * * * * * * * * * * * * * * * * */

        Vector2 previousPoint0 = this.GetPreviousPoint(this._trackedFingers[0]);
        Vector2 previousPoint1 = this.GetPreviousPoint(this._trackedFingers[1]);

        Vector2 previousDifference = previousPoint0 - previousPoint1;
        Vector2 currentDifference = this._trackedFingers[0].position - this._trackedFingers[1].position;

        float angle = Vector2.Angle(previousDifference, currentDifference);

        if(Vector2.Distance(this._trackedFingers[0].position, this._trackedFingers[1].position) >=
           (Screen.dpi * this._rotateProperty.MinDistance) &&
           angle >= this._rotateProperty.MinRotationChange) {
            this.FireRotateEvent(angle, previousDifference, currentDifference);
        }
    }

    private void FireRotateEvent(float angle, Vector2 previousDifference, Vector2 currentDifference) {
        Vector3 cross = Vector3.Cross(previousDifference, currentDifference);
        ERotateDirection direction;

        if(cross.z > 0)
            direction = ERotateDirection.COUNTERCLOCKWISE;
        else
            direction = ERotateDirection.CLOCKWISE;

        Vector2 midPoint = this.GetMidPoint(this._trackedFingers[0].position, this._trackedFingers[1].position);
        GameObject hitObject = this.GetHitObject(midPoint);

        RotateEventArgs args = new RotateEventArgs(this._trackedFingers, direction, angle, hitObject);

        if(this.OnRotate != null) {
            this.OnRotate(this, args);
        }

        if(hitObject != null) {
            IRotatable handler = hitObject.GetComponent<IRotatable>();
            if(handler != null) {
                handler.OnRotate(args);
            }
        }
    }

    private GameObject GetHitGraphic(Vector2 screenPoint) {
        PointerEventData pointerEventData = new PointerEventData(this._eventSystem);
        pointerEventData.position = screenPoint;

        List<RaycastResult> hits = new List<RaycastResult>();
        this._graphicRaycaster.Raycast(pointerEventData, hits);

        if(hits.Count > 0)
            return hits[0].gameObject;

        return null;
    }

    /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
     *                              HELPER METHODS                             *
     * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

    private GameObject GetHitObject(Vector2 screenPoint) {
        GameObject hitObject = null;
        Ray ray = Camera.main.ScreenPointToRay(screenPoint);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            hitObject = hit.collider.gameObject;

        return hitObject;
    }

    private Vector2 GetPreviousPoint(Touch finger) {
        return finger.position - finger.deltaPosition;
    }

    private Vector2 GetMidPoint(Vector2 pointA, Vector2 pointB) {
        return (pointA + pointB) / 2;
    }


    /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
     *                            LIFECYCLE METHODS                            *
     * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

    private void Awake() {
        if(Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    private void Update() {
        if(Input.touchCount > 0) {
            switch(Input.touchCount) {
                case 1:
                    this.CheckSingleFingerInput();
                    break;

                case 2:
                    this.CheckDualFingerInput();
                    break;
            }
        }
    }
}
