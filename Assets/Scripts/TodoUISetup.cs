using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TodoUISetup : MonoBehaviour
{
    // Automatische setup voor todo scene
    // Dit script zorgt dat alles correct is gekoppeld
    
    [SerializeField] private TodoManager todoManager;
    [SerializeField] private TMP_InputField todoInputField;
    [SerializeField] private Button addButton;
    [SerializeField] private Button clearAllButton;
    [SerializeField] private Transform todoListContainer;
    [SerializeField] private GameObject todoItemPrefab;

    void Start()
    {
        ValidateSetup();
    }

    void ValidateSetup()
    {
        if (todoManager == null)
            Debug.LogError("TodoManager niet gevonden!");
        if (todoInputField == null)
            Debug.LogError("InputField niet gevonden!");
        if (addButton == null)
            Debug.LogError("Add Button niet gevonden!");
        if (clearAllButton == null)
            Debug.LogError("Clear All Button niet gevonden!");
        if (todoListContainer == null)
            Debug.LogError("Todo List Container niet gevonden!");
        if (todoItemPrefab == null)
            Debug.LogError("Todo Item Prefab niet gevonden!");

        Debug.Log("Todo UI setup compleet!");
    }
}
