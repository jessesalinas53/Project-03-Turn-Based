using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingToken : MonoBehaviour, IBuffable
{
    [SerializeField] float _buffScaleInc = .5f;

    public void Buff()
    {
        transform.localScale = new Vector3(
            transform.localScale.x + _buffScaleInc,
            transform.localScale.y + _buffScaleInc,
            transform.localScale.z + _buffScaleInc);
    }

    public void Unbuff()
    {
        transform.localScale = new Vector3(
            transform.localScale.x - _buffScaleInc,
            transform.localScale.y - _buffScaleInc,
            transform.localScale.z - _buffScaleInc);
    }

}
