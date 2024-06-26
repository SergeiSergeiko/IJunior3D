using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    private TMP_Text _score;

    private void Start()
    {
        _score = GetComponentInChildren<TMP_Text>();
    }
    
    public void Refresh(int amount)
    {
        _score.text = $"Score {amount}";
    }
}