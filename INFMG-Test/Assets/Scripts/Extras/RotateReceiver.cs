using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*.............................................................................*
 |~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~|
 |                                INSTRUCTIONS                                 |
 |~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~|
 |'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''|
 | This script has INCOMPLETE code. Use [CTRL][F] to look for the [TODO] tags. |
 *'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''*/

public class RotateReceiver : MonoBehaviour, IRotatable {

    /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
     *                               PROPERTIES                                *
     * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

    private float _speedRotate = 30;

    /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
     *                             GENERAL METHODS                             *
     * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

    public void OnRotate(RotateEventArgs args) {

        /* * * * * * [TODO][X] * * * * * *
         |~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~|
         | Fill this script up with the  |
         | necessary logic. Refer to the |
         | document for more details.    |
         |~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~|
         * * * * * * * * * * * * * * * * */

        float angle = args.Angle * this._speedRotate * Time.deltaTime;

        if(args.Direction == ERotateDirection.CLOCKWISE) {
            angle = -angle;
        }

        this.transform.Rotate(0, 0, angle);

        switch(args.Direction) {
            case ERotateDirection.COUNTERCLOCKWISE:
                if(GUIManager.Instance.IsOpen)
                    GUIManager.Instance.Close();
                break;

            case ERotateDirection.CLOCKWISE:
                if(!GUIManager.Instance.IsOpen)
                    GUIManager.Instance.OpenEMF();
                break;
        }
    }
}
