using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARDrawLine : MonoBehaviour
{
    public Transform pivotPoint;
    public GameObject lineRendererPrefabs;
    private LineRenderer lineRenderer;
    public List<LineRenderer> lineList = new List<LineRenderer>();
    public Transform linePool;
    public bool isActive;
    public bool lineStarted;
    public Color color = Color.white;

    // Update is called once per frame
    void Update()
    {
        if (isActive && lineStarted) 
        {
            DrawLineContinue();
        }
    }

    public void MakeLineRenderer() 
    {
        GameObject line = Instantiate(lineRendererPrefabs);
        line.transform.SetParent(linePool);
        line.transform.position = Vector3.zero;
        line.transform.localScale = new Vector3(1, 1, 1);

        lineRenderer = line.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, pivotPoint.position);
        //lineRenderer.startColor = color;
        //lineRenderer.endColor = color;
        
        lineStarted = true;
        lineList.Add(lineRenderer);
    }

    public void StartDrawLine() 
    {
        isActive = true;
        if (!lineStarted) {
            MakeLineRenderer();
        }
    }

    public void StopDrawLine() 
    {
        isActive = false;
        lineStarted = false;
        lineRenderer = null;
    }

    public void DrawLineContinue() 
    {
        lineRenderer.positionCount = lineRenderer.positionCount+1;
        lineRenderer.SetPosition(lineRenderer.positionCount-1, pivotPoint.position);
    }

    public void ChangeLineColor(Color newColor)
    {
        color = newColor;
        if (lineRenderer != null)
        {
            lineRenderer.startColor = newColor;
            lineRenderer.endColor = newColor;
        }
    }

    public void DeleteLastLine()
    {
        if (lineList.Count > 0) 
        {
            LineRenderer lastLine = lineList[lineList.Count - 1];
            lineList.Remove(lastLine);
            Destroy(lastLine.gameObject);
        }
    }

}
