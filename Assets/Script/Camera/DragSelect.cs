using UnityEngine;

public class DragSelect : MonoBehaviour
{
    [SerializeField] RectTransform boxVisual;
    [SerializeField] private Camera camera;
    private Vector2 startPosition;
    private Vector2 endPosition;
    private Rect _selectArea;
    private void Awake()
    {
        startPosition = Vector2.zero;
        endPosition = Vector2.zero;
        drawArea();
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
            _selectArea = new Rect();
        }
        if (Input.GetMouseButton(0))
        {
            endPosition = Input.mousePosition;
            drawArea();
            selectArea();
        }
        if (Input.GetMouseButtonUp(0))
        {
            selectUnit();
            startPosition = Vector2.zero;
            endPosition = Vector2.zero;
            drawArea();
        }


    }

    void drawArea()
    {
        Vector2 boxStart = startPosition;
        Vector2 boxEnd = endPosition;

        Vector2 boxCenter = (boxStart + boxEnd) / 2;
        boxVisual.position = boxCenter;

        Vector2 boxSize = new Vector2(Mathf.Abs(boxStart.x - boxEnd.x), Mathf.Abs(boxStart.y - boxEnd.y));

        boxVisual.sizeDelta = boxSize;
    }

    void selectArea()
    {
        if (Input.mousePosition.x < startPosition.x)
        {
            _selectArea.xMin = Input.mousePosition.x;
            _selectArea.xMax = startPosition.x;
        }
        else
        {
            _selectArea.xMin = startPosition.x;
            _selectArea.xMax = Input.mousePosition.x;
        }

        if (Input.mousePosition.y < startPosition.y)
        {
            _selectArea.yMin = Input.mousePosition.y;
            _selectArea.yMax = startPosition.y;
        }
        else
        {
            _selectArea.yMin = startPosition.y;
            _selectArea.yMax = Input.mousePosition.y;
        }

    }

    void selectUnit()
    {
        foreach (var unit in Selection.Instance.unitList)
        {
            if (_selectArea.Contains(camera.WorldToScreenPoint(unit.transform.position)))
                Selection.Instance.dragSelect(unit);
        }
    }

}
