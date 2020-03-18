using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEManager : MonoBehaviour
{
    private QTEType qteType;

    public void SetQTEType(QTEType qteType)
    {
        this.qteType = qteType;
    }

    public virtual void StartQTE(QTEType qteType, int buildingLevel) { }

}

public enum QTEType
{
    Gold = 0,
    Wood = 1,
    Iron = 2,
    Food = 3,
    Oil = 4
}
