using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class TodoManager : MonoBehaviour
{
    public TMP_InputField todoInputField;
    public Button addButton;
    public Button clearAllButton;
    public RectTransform todoListContainer;
    
    private List<string> todos = new List<string>();
    private GameObject todoItemPrefab;
    
    void Start()
    {
        // Maak prefab voor todo items
        CreateTodoItemPrefab();
        
        // Koppel buttons
        if (addButton != null)
            addButton.onClick.AddListener(AddTodo);
        
        if (clearAllButton != null)
            clearAllButton.onClick.AddListener(ClearAllTodos);
        
        // Zet placeholder text
        if (todoInputField != null)
            todoInputField.placeholder.GetComponent<TextMeshProUGUI>().text = "Voer een taak in...";
    }
    
    void CreateTodoItemPrefab()
    {
        // Maak een eenvoudige todo item prefab
        todoItemPrefab = new GameObject("TodoItem");
        todoItemPrefab.SetActive(false);
        
        // Voeg een layout element toe
        RectTransform rect = todoItemPrefab.AddComponent<RectTransform>();
        rect.sizeDelta = new Vector2(0, 50);
        
        // Voeg een background image toe
        Image bg = todoItemPrefab.AddComponent<Image>();
        bg.color = new Color(0.3f, 0.3f, 0.3f, 1f);
        
        // Voeg een horizontal layout toe voor buttons
        HorizontalLayoutGroup hlg = todoItemPrefab.AddComponent<HorizontalLayoutGroup>();
        hlg.spacing = 5;
        hlg.padding = new RectOffset(5, 5, 5, 5);
        hlg.childForceExpandHeight = true;
        hlg.childForceExpandWidth = false;
        
        // Voeg tekst toe
        GameObject textGO = new GameObject("Text");
        textGO.transform.SetParent(todoItemPrefab.transform, false);
        TextMeshProUGUI text = textGO.AddComponent<TextMeshProUGUI>();
        text.text = "Taak";
        text.fontSize = 24;
        text.alignment = TextAlignmentOptions.MidlineLeft;
        text.color = Color.white;
        
        RectTransform textRect = textGO.GetComponent<RectTransform>();
        textRect.flexibleWidth = 1;
        
        // Voeg delete button toe
        GameObject deleteButtonGO = new GameObject("DeleteButton");
        deleteButtonGO.transform.SetParent(todoItemPrefab.transform, false);
        
        Image deleteImage = deleteButtonGO.AddComponent<Image>();
        deleteImage.color = new Color(0.8f, 0.2f, 0.2f, 1f);
        
        Button deleteButton = deleteButtonGO.AddComponent<Button>();
        
        RectTransform deleteRect = deleteButtonGO.GetComponent<RectTransform>();
        deleteRect.sizeDelta = new Vector2(60, 40);
        
        // Delete button text
        GameObject deleteTextGO = new GameObject("Text");
        deleteTextGO.transform.SetParent(deleteButtonGO.transform, false);
        TextMeshProUGUI deleteText = deleteTextGO.AddComponent<TextMeshProUGUI>();
        deleteText.text = "X";
        deleteText.fontSize = 30;
        deleteText.alignment = TextAlignmentOptions.Center;
        deleteText.color = Color.white;
        
        RectTransform deleteTextRect = deleteTextGO.GetComponent<RectTransform>();
        deleteTextRect.anchorMin = Vector2.zero;
        deleteTextRect.anchorMax = Vector2.one;
        deleteTextRect.offsetMin = Vector2.zero;
        deleteTextRect.offsetMax = Vector2.zero;
    }
    
    public void AddTodo()
    {
        if (todoInputField == null || string.IsNullOrWhiteSpace(todoInputField.text))
            return;
        
        string todoText = todoInputField.text;
        todos.Add(todoText);
        
        // Maak UI item
        GameObject item = Instantiate(todoItemPrefab, todoListContainer);
        item.SetActive(true);
        
        // Update tekst
        TextMeshProUGUI itemText = item.GetComponentInChildren<TextMeshProUGUI>();
        if (itemText != null)
            itemText.text = todoText;
        
        // Maak delete button werkend
        Button deleteBtn = item.GetComponentInChildren<Button>();
        if (deleteBtn != null)
        {
            int index = todos.Count - 1;
            deleteBtn.onClick.AddListener(() => DeleteTodo(index, item));
        }
        
        // Clear input
        todoInputField.text = "";
        todoInputField.ActivateInputField();
    }
    
    public void DeleteTodo(int index, GameObject item)
    {
        if (index >= 0 && index < todos.Count)
        {
            todos.RemoveAt(index);
            Destroy(item);
        }
    }
    
    public void ClearAllTodos()
    {
        todos.Clear();
        
        // Verwijder alle items
        foreach (Transform child in todoListContainer)
        {
            Destroy(child.gameObject);
        }
        
        todoInputField.text = "";
    }
}