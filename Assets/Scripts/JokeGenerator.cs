using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System.Collections;

public class JokeGenerator : MonoBehaviour
{
    public TextMeshProUGUI jokeText;
    public Button getJokeButton;
    
    void Start()
    {
        if (getJokeButton != null)
            getJokeButton.onClick.AddListener(GetNewJoke);
        
        if (jokeText != null)
            jokeText.text = "Druk op de knop voor een grap! 😄";
    }
    
    public void GetNewJoke()
    {
        StartCoroutine(FetchJoke());
    }
    
    IEnumerator FetchJoke()
    {
        if (jokeText != null)
            jokeText.text = "Even wachten... ⏳";
        
        // Gebruik de free JokeAPI
        string url = "https://official-joke-api.appspot.com/random_joke";
        
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();
            
            if (request.result == UnityWebRequest.Result.Success)
            {
                string jsonData = request.downloadHandler.text;
                JokeData jokeData = JsonUtility.FromJson<JokeData>(jsonData);
                
                if (jokeText != null)
                    jokeText.text = $"{jokeData.setup}\n\n{jokeData.punchline} 😂";
            }
            else
            {
                if (jokeText != null)
                    jokeText.text = "Fout bij laden van grap! ❌";
            }
        }
    }
}

[System.Serializable]
public class JokeData
{
    public string setup;
    public string punchline;
    public int id;
    public string type;
}