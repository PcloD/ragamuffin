﻿using UnityEngine;

public class Grid : MonoBehaviour {

    public float StartX = 0.0f;
    public float StartY = 0.0f;

    public float CellWidth = 10.0f; 
    public float CellHeight = 10.0f;

    public int NumCellsX = 20;
    public int NumCellsY = 10;

    public float IconSize = 0.1f;

    public Vector3[,] grid;

    void Start()
    {
        grid = new Vector3[NumCellsX, NumCellsY];
    }

    void CreateGrid()
    {
        grid = new Vector3[NumCellsX, NumCellsY];

        for (int x = 0; x < NumCellsX; x++) {
            for (int y = 0; y < NumCellsY; y++) {
                grid[x, y] = new Vector3(x * CellWidth + StartX, y * CellHeight + StartY, 0);
            }
        }
    }

    void OnDrawGizmos()
    {
        // todo: only re-create grid on change in inspector
        CreateGrid();

        for (int x = 0; x < NumCellsX; x++) {
            for (int y = 0; y < NumCellsY; y++) {
                Gizmos.DrawSphere(grid[x,y], IconSize);
            }
        }
    }

    public Vector3 FindClosestGridPos(Vector3 pos)
	{
        if(grid.Length == 0)
            return pos;

		Vector3 closestGridPoint = grid[0,0];
		foreach(Vector3 point in grid)
		{
			if (Mathf.Abs(Vector3.Distance(point, pos)) < Mathf.Abs(Vector3.Distance(closestGridPoint, pos)))
				closestGridPoint = point;
		}
		closestGridPoint.z = 0;

		return closestGridPoint;
	}

}
