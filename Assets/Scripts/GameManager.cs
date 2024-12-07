using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int[,] grid = new int[10, 20]; // Игровое поле: 10 ширина, 20 высота

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckForLineClear();
        }
    }

    void CheckForLineClear()
    {
        for (int y = 0; y < grid.GetLength(1); y++)
        {
            bool lineCleared = true;

            for (int x = 0; x < grid.GetLength(0); x++)
            {
                if (grid[x, y] == 0)
                {
                    lineCleared = false;
                    break;
                }
            }

            if (lineCleared)
            {
                ClearLine(y);
            }
        }
    }

    void ClearLine(int rowIndex)
    {
        for (int y = rowIndex; y < grid.GetLength(1) - 1; y++)
        {
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                grid[x, y] = grid[x, y + 1];
            }
        }

        for (int x = 0; x < grid.GetLength(0); x++)
        {
            grid[x, grid.GetLength(1) - 1] = 0;
        }

        Debug.Log($"Строка {rowIndex} уничтожена!");

        // Увеличиваем счёт
        FindObjectOfType<ScoreManager>().AddScore(100);
    }
}
