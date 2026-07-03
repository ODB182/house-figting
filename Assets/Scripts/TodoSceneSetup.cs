using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class TodoSceneSetup : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void SetupTodoScene()
    {
        // Maak Canvas
        GameObject canvasGO = new GameObject("Canvas");
        Canvas canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        
        CanvasScaler scaler = canvasGO.AddComponent<CanvasScaler>();
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.referenceResolution = new Vector2(1920, 1080);
        
        GraphicRaycaster raycaster = canvasGO.AddComponent<GraphicRaycaster>();
        
        RectTransform canvasRect = canvasGO.GetComponent<RectTransform>();
        canvasRect.anchorMin = Vector2.zero;
        canvasRect.anchorMax = Vector2.one;
        canvasRect.offsetMin = Vector2.zero;
        canvasRect.offsetMax = Vector2.zero;
        
        // EventSystem
        new GameObject("EventSystem").AddComponent<EventSystem>();
        
        // Maak Main Panel (achtergrond)
        GameObject panelGO = new GameObject("Panel");
        panelGO.transform.SetParent(canvasGO.transform, false);
        Image panelImage = panelGO.AddComponent<Image>();
        panelImage.color = new Color(0.15f, 0.15f, 0.15f, 1f);
        
        RectTransform panelRect = panelGO.GetComponent<RectTransform>();
        panelRect.anchorMin = Vector2.zero;
        panelRect.anchorMax = Vector2.one;
        panelRect.offsetMin = Vector2.zero;
        panelRect.offsetMax = Vector2.zero;
        
        // Titel
        GameObject titleGO = new GameObject("Title");
        titleGO.transform.SetParent(panelGO.transform, false);
        TextMeshProUGUI titleText = titleGO.AddComponent<TextMeshProUGUI>();
        titleText.text = "Mijn Taken 📝";
        titleText.fontSize = 50;
        titleText.alignment = TextAlignmentOptions.TopCenter;
        titleText.color = Color.white;
        
        RectTransform titleRect = titleGO.GetComponent<RectTransform>();
        titleRect.anchorMin = new Vector2(0.5f, 1f);
        titleRect.anchorMax = new Vector2(0.5f, 1f);
        titleRect.anchoredPosition = new Vector2(0, -40);
        titleRect.sizeDelta = new Vector2(800, 80);
        
        // Input Field
        GameObject inputFieldGO = new GameObject("TodoInputField");
        inputFieldGO.transform.SetParent(panelGO.transform, false);
        
        Image inputBg = inputFieldGO.AddComponent<Image>();
        inputBg.color = new Color(0.2f, 0.2f, 0.2f, 1f);
        
        TMP_InputField inputField = inputFieldGO.AddComponent<TMP_InputField>();
        inputField.textViewport = inputFieldGO.GetComponent<RectTransform>();
        
        RectTransform inputRect = inputFieldGO.GetComponent<RectTransform>();
        inputRect.anchorMin = new Vector2(0.5f, 1f);
        inputRect.anchorMax = new Vector2(0.5f, 1f);
        inputRect.anchoredPosition = new Vector2(0, -150);
        inputRect.sizeDelta = new Vector2(600, 50);
        
        // Add Button
        GameObject addButtonGO = new GameObject("AddButton");
        addButtonGO.transform.SetParent(panelGO.transform, false);
        
        Image addBg = addButtonGO.AddComponent<Image>();
        addBg.color = new Color(0.2f, 0.8f, 0.2f, 1f);
        
        Button addButton = addButtonGO.AddComponent<Button>();
        
        RectTransform addButtonRect = addButtonGO.GetComponent<RectTransform>();
        addButtonRect.anchorMin = new Vector2(0.5f, 1f);
        addButtonRect.anchorMax = new Vector2(0.5f, 1f);
        addButtonRect.anchoredPosition = new Vector2(0, -220);
        addButtonRect.sizeDelta = new Vector2(120, 50);
        
        // Add Button Text
        GameObject addTextGO = new GameObject("Text");
        addTextGO.transform.SetParent(addButtonGO.transform, false);
        TextMeshProUGUI addText = addTextGO.AddComponent<TextMeshProUGUI>();
        addText.text = "Toevoegen";
        addText.fontSize = 30;
        addText.alignment = TextAlignmentOptions.Center;
        addText.color = Color.white;
        
        RectTransform addTextRect = addTextGO.GetComponent<RectTransform>();
        addTextRect.anchorMin = Vector2.zero;
        addTextRect.anchorMax = Vector2.one;
        addTextRect.offsetMin = Vector2.zero;
        addTextRect.offsetMax = Vector2.zero;
        
        // Scroll View (voor takenlijst)
        GameObject scrollGO = new GameObject("ScrollView");
        scrollGO.transform.SetParent(panelGO.transform, false);
        
        Image scrollBg = scrollGO.AddComponent<Image>();
        scrollBg.color = new Color(0.1f, 0.1f, 0.1f, 1f);
        
        ScrollRect scrollRect = scrollGO.AddComponent<ScrollRect>();
        scrollRect.vertical = true;
        scrollRect.horizontal = false;
        
        RectTransform scrollRectTrans = scrollGO.GetComponent<RectTransform>();
        scrollRectTrans.anchorMin = new Vector2(0.1f, 0.1f);
        scrollRectTrans.anchorMax = new Vector2(0.9f, 0.85f);
        scrollRectTrans.offsetMin = Vector2.zero;
        scrollRectTrans.offsetMax = Vector2.zero;
        
        // Content (voor de taken)
        GameObject contentGO = new GameObject("Content");
        contentGO.transform.SetParent(scrollGO.transform, false);
        
        RectTransform contentRect = contentGO.GetComponent<RectTransform>();
        contentRect.anchorMin = new Vector2(0f, 1f);
        contentRect.anchorMax = new Vector2(1f, 1f);
        contentRect.pivot = new Vector2(0.5f, 1f);
        contentRect.sizeDelta = new Vector2(0, 0);
        
        VerticalLayoutGroup vlg = contentGO.AddComponent<VerticalLayoutGroup>();
        vlg.spacing = 5;
        vlg.padding = new RectOffset(10, 10, 10, 10);
        vlg.childForceExpandHeight = false;
        vlg.childForceExpandWidth = true;
        
        scrollRect.content = contentRect;
        
        // Clear All Button
        GameObject clearButtonGO = new GameObject("ClearAllButton");
        clearButtonGO.transform.SetParent(panelGO.transform, false);
        
        Image clearBg = clearButtonGO.AddComponent<Image>();
        clearBg.color = new Color(0.8f, 0.2f, 0.2f, 1f);
        
        Button clearButton = clearButtonGO.AddComponent<Button>();
        
        RectTransform clearButtonRect = clearButtonGO.GetComponent<RectTransform>();
        clearButtonRect.anchorMin = new Vector2(0.5f, 0f);
        clearButtonRect.anchorMax = new Vector2(0.5f, 0f);
        clearButtonRect.anchoredPosition = new Vector2(0, 20);
        clearButtonRect.sizeDelta = new Vector2(120, 50);
        
        // Clear Button Text
        GameObject clearTextGO = new GameObject("Text");
        clearTextGO.transform.SetParent(clearButtonGO.transform, false);
        TextMeshProUGUI clearText = clearTextGO.AddComponent<TextMeshProUGUI>();
        clearText.text = "Alles wissen";
        clearText.fontSize = 25;
        clearText.alignment = TextAlignmentOptions.Center;
        clearText.color = Color.white;
        
        RectTransform clearTextRect = clearTextGO.GetComponent<RectTransform>();
        clearTextRect.anchorMin = Vector2.zero;
        clearTextRect.anchorMax = Vector2.one;
        clearTextRect.offsetMin = Vector2.zero;
        clearTextRect.offsetMax = Vector2.zero;
        
        // Voeg TodoManager toe
        GameObject managerGO = new GameObject("TodoManager");
        TodoManager manager = managerGO.AddComponent<TodoManager>();
        manager.todoInputField = inputField;
        manager.addButton = addButton;
        manager.todoListContainer = contentRect;
        manager.clearAllButton = clearButton;
    }
}
