using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField] private TableData tableLayout; // Referenz zu TableLayout
    [SerializeField] private StudentData[] students; // Schülerdaten mit Bild
    [SerializeField] private GameObject tablePrefab; // Tisch Prefab
    [SerializeField] private GameObject chairPrefab; // Stuhl Prefab

    public int studentIndex = 0; // Um durch die Schülerdaten zu iterieren

    void Start()
    {

        Debug.Log($"Students array length: {students.Length}");
        for (int i = 0; i < students.Length; i++)
        {
            Debug.Log($"Student {i}: {students[i].name}, Image: {students[i].studentImage}");
        }
        for (int row = 0; row < tableLayout.rows; row++)
        {
            for (int column = 0; column < tableLayout.columns; column++)
            {
                Vector3 tablePosition = new Vector3(column * tableLayout.tableSpacing, 0, row * tableLayout.tableSpacing);
                GameObject table = Instantiate(tablePrefab, tablePosition, Quaternion.identity, transform);
                AssignStudentToChair(table);
            }
        }
    }

    public void AssignStudentToChair(GameObject table)
    {
        Transform[] allTransforms = table.GetComponentsInChildren<Transform>();
        foreach (var transform in allTransforms)
        {
            if (transform.name.StartsWith("StudentImage"))
            {
                if (studentIndex >= students.Length)
                {
                    Debug.LogWarning("No more students to assign!");
                    return;
                }

                StudentData student = students[studentIndex];
                studentIndex++;

                Debug.Log($"Assigning student: {student.name} with image: {student.studentImage}");
                var imageComponent = transform.GetComponent<UnityEngine.UI.Image>();
                if (imageComponent != null)
                {
                    if (student.studentImage != null)
                    {
                        imageComponent.sprite = student.studentImage;
                        Debug.Log($"Successfully set image for {student.name} on {transform.name}");
                    }
                    else
                    {
                        Debug.LogWarning($"Student {student.name} has no image!");
                    }
                }
                else
                {
                    Debug.LogWarning($"No Image component found on {transform.name}");
                }
            }
        }
    }

}