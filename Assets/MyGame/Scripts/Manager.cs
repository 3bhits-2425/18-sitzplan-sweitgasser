using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    [SerializeField] private TableData tableLayout; // ref zu Tablelayout
    [SerializeField] private StudentData[] students;
    [SerializeField] private GameObject tablePrefab;
    [SerializeField] private GameObject chairPrefab;


    void Start()
    {
        for (int row = 0; row < tableLayout.rows; row++)
        {
            for (int columns = 0; columns < tableLayout.columns; columns++)
            {
                Vector3 tablePosition = new Vector3(columns * tableLayout.tableSpacing, 0, row * tableLayout.tableSpacing);
                GameObject table = Instantiate(tablePrefab, tablePosition, Quaternion.identity, transform);
                // Sesselplatzieren 
                Transform pos1 = table.transform.Find("pos1");
                Transform pos2 = table.transform.Find("pos2");
                if (pos1)
                {
                    Instantiate(chairPrefab, pos1.position, pos1.rotation, table.transform);
                }
                if (pos2)
                {
                    Instantiate(chairPrefab, pos2.position, pos2.rotation, table.transform);
                }

            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

