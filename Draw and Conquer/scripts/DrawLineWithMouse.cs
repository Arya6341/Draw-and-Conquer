using UnityEngine;
using System.Collections.Generic;

public class DrawLineWithMouse : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public int maxLines = 3; // Set the max number of lines in the inspector

    private List<Vector3> mousePositions = new List<Vector3>();
    private List<Vector2> edgePoints = new List<Vector2>();
    private int lineDrawCount = 0; // Track how many times lines have been drawn

    void Start()
    {
        // Configure the line's appearance
        lineRenderer.positionCount = 0;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        // Configure the collider
        edgeCollider.edgeRadius = 0.05f; // Adjust the thickness of the collider
        edgeCollider.isTrigger = true; // Set as trigger if you don't want physical collisions
    }

    void Update()
    {
        // Detect left mouse button down
        if (Input.GetMouseButtonDown(0))
        {
            if (lineDrawCount < maxLines)
            {
                // Clear previous line and collider points
                mousePositions.Clear();
                edgePoints.Clear();
                lineRenderer.positionCount = 0;
                edgeCollider.Reset();
            }
            else
            {
                // Destroy the line and collider after maxLines is reached
                Destroy(lineRenderer.gameObject);
                Destroy(edgeCollider);
            }
        }

        // Detect left mouse button held down (for drawing)
        if (Input.GetMouseButton(0) && lineDrawCount < maxLines)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f; // Set a distance from the camera

            // Convert mouse position to world position
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

            // Only add the position if it's not already recorded (prevents duplicates)
            if (mousePositions.Count == 0 || Vector3.Distance(mousePositions[mousePositions.Count - 1], worldPosition) > 0.1f)
            {
                mousePositions.Add(worldPosition);
                lineRenderer.positionCount = mousePositions.Count;
                lineRenderer.SetPosition(mousePositions.Count - 1, worldPosition);

                // Add position to the collider
                edgePoints.Add(new Vector2(worldPosition.x, worldPosition.y));
                edgeCollider.SetPoints(edgePoints); // Update the collider with new points
            }
        }

        // If the mouse button is released and a line was drawn, increase the draw count
        if (Input.GetMouseButtonUp(0) && mousePositions.Count > 0)
        {
            lineDrawCount++; // Increment the draw count
        }
    }
}
