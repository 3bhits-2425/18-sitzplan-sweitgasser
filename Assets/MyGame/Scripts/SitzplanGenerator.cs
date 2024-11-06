using UnityEngine;

public class SitzplanGenerator : MonoBehaviour
{
    public GameObject sitzPrefab;   // Das Prefab für den Sitz (Quadrat)
    public Sprite[] sitzSprites;    // Array für 19 verschiedene Sprites (Bilder)
    public int rows = 5;            // Anzahl der Reihen
    public int columns = 5;         // Anzahl der Spalten (hier 4, um 5x4 zu erreichen)
    public float spacing = 20.0f;   // Abstand zwischen den Quadraten
    [SerializeField] private GameObject myParent;  // Parent-Objekt

    void Start()
    {
        GenerateSitzplan();  // Startet die Generierung des Sitzplans
    }

    void GenerateSitzplan()
    {
        int totalSeats = rows * columns;
        if (sitzSprites.Length != totalSeats)
        {
            Debug.LogError("Die Anzahl der Sprites muss genau der Anzahl der Sitze entsprechen.");
            return;
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Vector3 position = new Vector3(i * spacing, j * spacing, 0);
                GameObject neuerSitz = Instantiate(sitzPrefab, position, Quaternion.identity);
                neuerSitz.transform.SetParent(myParent.transform);

                SpriteRenderer spriteRenderer = neuerSitz.GetComponent<SpriteRenderer>();

                // Die Logik, um jedem Quadrat ein einzigartiges Bild zuzuweisen
                int index = i * columns + j;  // Eindeutiger Index für jeden Sitz
                if (index < sitzSprites.Length)
                {
                    spriteRenderer.sprite = sitzSprites[index];
                }

                // Skalierung anpassen (z. B. auf 0.5, um das Sprite zu verkleinern)
                neuerSitz.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            }
        }
    }
}
