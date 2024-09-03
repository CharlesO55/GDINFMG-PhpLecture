using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*.............................................................................*
 |~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~|
 |                                INSTRUCTIONS                                 |
 |~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~|
 |'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''|
 | You are free to alter this script as you see fit. Just make sure that the   |
 | resulting script still acts in accordance with what was discussed in class. |
 *'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''*/

public class RotateEventArgs : EventArgs {
    private Touch[] _trackedFingers;
    public Touch[] TrackedFinger {
        get { return this._trackedFingers; }
    }

    private ERotateDirection _direction;
    public ERotateDirection Direction {
        get { return this._direction; }
    }

    private float _angle;
    public float Angle { 
        get { return this._angle; }
    }

    private GameObject _hitObject;
    public GameObject HitObject {
        get { return _hitObject; }
    }

    public RotateEventArgs(Touch[] trackedFingers, ERotateDirection direction, float angle, GameObject hitObject) {
        this._trackedFingers = trackedFingers;
        this._direction = direction;
        this._angle = angle;
        this._hitObject = hitObject;
    }
}
