using UnityEngine;

[CreateAssetMenu(fileName = "NewTableLayout", menuName = "Seatplan/TableLayout")]
public class TableData : ScriptableObject
{
    public int rows;
    public int columns;
    public float tableSpacing;
    public float chairSpacing;
}
