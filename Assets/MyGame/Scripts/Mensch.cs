using UnityEngine;

public class Mensch : MonoBehaviour
{
    // Instanzvariablen
    public string personName;
    public string rolleInKlasse;
    public Color augenfarbe;
   

    [SerializeField] private AudioSource myAudioSource;
    [SerializeField] private GameObject myGameObject;
    // Start wird aufgerufen, bevor das erste Frame aktualisiert wird
    void Start()
    {
        Debug.Log("Mein Name: " + personName);
        Debug.Log("Meine Rolle: " + rolleInKlasse);
        Debug.Log("Meine Augenfarbe: " + augenfarbe);

        myGameObject = GetComponent<GameObject>();

        // Hole die Komponente Audio Source beim Starten des GameObjects
        myAudioSource = GetComponent<AudioSource>(); // < DATENTYP >
    }

    // Methode zum Setzen der Personendaten (muss public sein)
    public void SetzePersonDaten(string name, string rolle, Color augenfarbe)
    {
        this.personName = name;
        this.rolleInKlasse = rolle;
        this.augenfarbe = augenfarbe;
    }

    // Update wird einmal pro Frame aufgerufen
    void Update()
    {
        // sobald die Leertaste gedrückt wird
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Leertaste gedrückt!");
            // Starte die Audio-Wiedergabe
            myAudioSource.Play();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Leertaste losgelassen!");
            myAudioSource.Pause();
        }
    }
}
