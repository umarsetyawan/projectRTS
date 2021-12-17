using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Behaviour")]
    [SerializeField] private bool useRootOffset = true;
    [SerializeField] private float edgeBorderDetect = 5f;

    [Header("Config")]
    [SerializeField] private float moveSpeed = 500f;

    [Space]
    [SerializeField] private float zoomDistance = 50;
    [SerializeField] private float zoomMultiplier = 1f;
    [SerializeField] private Vector2 zoomLimit = new Vector2(0.5f, 5f);
    [SerializeField] private bool enableSmoothZoom = true;
    [SerializeField] private float zoomSmoothTime = 0.5f;

    [Header("Input")]
    [SerializeField] private bool enableEdgeScroll = true;
    [SerializeField] private bool enableZoom = true;
    [SerializeField] private float scrollSensitivity = 0.5f;
    [SerializeField] private bool inverseZoom;

    Vector3 camOffsetDir;
    Vector2 screenRes;
    Vector2 mousePos;
    Vector3 _worldPos;

    float _zoomValue;
    float _smoothZoomVelocity;

    public bool ZoomControl { get { return enableZoom; } set { enableZoom = true; } }
    public bool MoveControl { get { return enableEdgeScroll; } set { enableEdgeScroll = true; } }


    bool EdgeDirection(ref Vector2 outDirection)
    {
        outDirection = Vector2.zero;
        screenRes.Set(Screen.width, Screen.height);
        mousePos.Set(Input.mousePosition.x, Input.mousePosition.y);

        outDirection = Vector2.zero;

        // Horizontal
        if (mousePos.x < edgeBorderDetect)
            outDirection += Vector2.left;
        if (mousePos.x > screenRes.x - edgeBorderDetect)
            outDirection += Vector2.right;

        if (mousePos.y > screenRes.y - edgeBorderDetect)
            outDirection += Vector2.up;
        if (mousePos.y < edgeBorderDetect)
            outDirection += Vector2.down;

        return (outDirection != Vector2.zero);
    }

    private void Awake()
    {
        camOffsetDir = transform.position.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 _edgedir = Vector2.zero;
        EdgeDirection(ref _edgedir);

        Vector3 dir = new Vector3(_edgedir.x, 0, _edgedir.y);

        if (ZoomControl)
        {
            _zoomValue += (inverseZoom ? -Input.mouseScrollDelta.y : Input.mouseScrollDelta.y) * scrollSensitivity;
            _zoomValue = Mathf.Clamp(_zoomValue, zoomLimit.x, zoomLimit.y);
            if (enableSmoothZoom)
                zoomMultiplier = Mathf.SmoothDamp(zoomMultiplier, _zoomValue, ref _smoothZoomVelocity, zoomSmoothTime);
            else
                zoomMultiplier = _zoomValue;
        }
        if(MoveControl)
            _worldPos += ((new Vector3(dir.x, 0, dir.z) * moveSpeed) * Time.deltaTime);

        Vector3 camOffset = (camOffsetDir * zoomDistance) * zoomMultiplier;
        transform.position = camOffset + _worldPos;


    }

}
