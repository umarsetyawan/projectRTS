using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingState : BaseState
{
    private GameObject _Building;
    private Vector3 direction;
    public override void StartState(GameObject Unit)
    {
        base.StartState(Unit);
        _Building = Unit;
        Debug.Log(_Building.name);
    }

    public override void UpdateState(float DeltaTime)
    {
        base.UpdateState(DeltaTime);
        SetDirection();
    }

    public override void TerminateState()
    {
        base.TerminateState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }


    private void SetDirection()
    {
        Vector3 _dir = Vector3.zero;
        direction = GameManager.Instance.MousePosition - _Building.transform.position;
        _dir = direction.normalized;

        if (_dir.x <= -0.5)
        {
            Debug.Log("Left");
            Quaternion yawRotation = Quaternion.AngleAxis(-90f, Vector3.up);
            _Building.transform.rotation = yawRotation;
        }
        if (_dir.x >= 0.5)
        {
            Debug.Log("Right");
            Quaternion yawRotation = Quaternion.AngleAxis(90f, Vector3.up);
            _Building.transform.rotation = yawRotation;
        }
        if (_dir.z <= -0.5)
        {
            Debug.Log("down");
            Quaternion yawRotation = Quaternion.AngleAxis(180f, Vector3.up);
            _Building.transform.rotation = yawRotation;
        }
        if (_dir.z >= 0.5)
        {
            Debug.Log("Up");
            Quaternion yawRotation = Quaternion.AngleAxis(0f, Vector3.up);
            _Building.transform.rotation = yawRotation;
        }
    }
}