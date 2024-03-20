using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRenderer : MonoBehaviour
{

    [SerializeField]
    [Range(1, 50)]
    public int width = 4;

    [SerializeField]
    [Range(1, 50)]
    public int height = 4;

    [SerializeField]
    private Transform wallPrefab = null;

    [SerializeField]
    public float size = 2f;

    [SerializeField]
    private Transform floorPrefab = null;


    void Start()
    {
        var maze = MazeGenerator.Generate(width, height);
        Draw(maze);
    }

    private void Draw(WallState[,] maze)
    {

        

        var floor = Instantiate(floorPrefab, transform);
        floor.localScale = new Vector3(width * size, 1f, height * size);
        floor.localPosition = new Vector3(0, -1, 0);

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                var cell = maze[i, j];
                var position = new Vector3((-width * size/ 2 ) + (i * size) +size/2, 0, -height *size / 2 + (j * size) +size/2);

                if (cell.HasFlag(WallState.UP))
                {
                    var topWall = Instantiate(wallPrefab, transform) as Transform;
                    topWall.position = position + new Vector3(0, 0, size / 2);
                    topWall.localScale = new Vector3(size, topWall.localScale.y, topWall.localScale.z);


                }
                if (cell.HasFlag(WallState.LEFT))
                {
                    var leftWall = Instantiate(wallPrefab, transform) as Transform;
                    leftWall.position = position + new Vector3(-size / 2, 0, 0);
                    leftWall.eulerAngles = new Vector3(0, 90, 0);
                    leftWall.localScale = new Vector3(size, leftWall.localScale.y, leftWall.localScale.z);
                }

                if (i == width - 1)
                {
                    if (cell.HasFlag(WallState.RIGHT))
                    {
                        var rightWall = Instantiate(wallPrefab, transform) as Transform;
                        rightWall.position = position + new Vector3(size / 2, 0, 0);
                        rightWall.eulerAngles = new Vector3(0, 90, 0);
                        rightWall.localScale = new Vector3(size, rightWall.localScale.y, rightWall.localScale.z);
                    }
                }

                if (j == 0)
                {
                    if (cell.HasFlag(WallState.DOWN))
                    {
                        var bottomWall = Instantiate(wallPrefab, transform) as Transform;
                        bottomWall.position = position + new Vector3(0, 0, -size / 2);
                        bottomWall.localScale = new Vector3(size, bottomWall.localScale.y, bottomWall.localScale.z);
                    }
                }
            }
        }
    }
}
