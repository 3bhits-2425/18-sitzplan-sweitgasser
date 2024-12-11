using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager2 : MonoBehaviour
{
    [SerializeField] private TableData tableLayout; // Referenz zu TableLayout
    [SerializeField] private StudentData[] students; // Schülerdaten mit Bild
    [SerializeField] private GameObject tablePrefab; // Tisch Prefab
    [SerializeField] private GameObject chairPrefab; // Stuhl Prefab

    private int studentIndex = 0; // Um durch die Schülerdaten zu iterieren

    
    void Start()
    {
        for (int row = 0; row < tableLayout.rows; row++)
        {
            for (int column = 0; column < tableLayout.columns; column++)
            {
                Vector3 tablePosition = new Vector3(column * tableLayout.tableSpacing, 0, row * tableLayout.tableSpacing);
                GameObject table = Instantiate(tablePrefab, tablePosition, Quaternion.identity, transform);

                // Sessel platzieren
                Transform pos1 = table.transform.Find("pos1");
                Transform pos2 = table.transform.Find("pos2");

                if (pos1)
                {
                    GameObject chair1 = Instantiate(chairPrefab, pos1.position, pos1.rotation, table.transform);
                    AssignStudentToChair(chair1);
                }

                if (pos2)
                {
                    GameObject chair2 = Instantiate(chairPrefab, pos2.position, pos2.rotation, table.transform);
                    AssignStudentToChair(chair2);
                }
            }
        }
    }
    private void AssignStudentToChair(GameObject chair) {
        if (studentIndex >= students.Length)
        {
            Debug.LogWarning("No more students to assign!");

        }
}
}
