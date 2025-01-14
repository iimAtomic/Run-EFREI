using UnityEngine;

[ExecuteInEditMode]
public class MultiBoxColliderSetup : MonoBehaviour
{
    void Start()
    {
        // Évite de créer des colliders en double
        if (Application.isPlaying) return;

        // Supprimer les colliders existants pour éviter les doublons
        foreach (var collider in GetComponents<BoxCollider>())
        {
            DestroyImmediate(collider);
        }

        // Collider pour l'avant et arrière bas
        BoxCollider lowBox = gameObject.AddComponent<BoxCollider>();
        lowBox.center = new Vector3(0.005122f, 1.2f, 0.2f); // Position
        lowBox.size = new Vector3(3.626759f, 1.112989f, 9.100351f); // Taille

        // Collider pour le haut du camion
        BoxCollider highBox = gameObject.AddComponent<BoxCollider>();
        highBox.center = new Vector3(0f, 2f, 3.3f); // Position
        highBox.size = new Vector3(3.626759f, 2.992825f, 2.46165f); // Taille

        // Collider pour l'arrière haut
        BoxCollider rearBox = gameObject.AddComponent<BoxCollider>();
        rearBox.center = new Vector3(0.005122f, 1.35f, -4.4f); // Position
        rearBox.size = new Vector3(3.626759f, 1.792299f, 0.5f); // Taille
    }
}
