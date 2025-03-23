using UnityEngine;
using UnityEngine.Events;

public class Survival : MonoBehaviour
{
    [Header("Hunger")]
    [SerializeField] private float _maxHunger = 100f;
    [SerializeField] private float _hungerDepletionRate = 1f;
    private float _currentHunger;
    public float HungerPercent => _currentHunger / _maxHunger;

    [Header("Thirst")]
    [SerializeField] private float _maxThirst = 100f;
    [SerializeField] private float _thirstDepletionRate = 1f;
    private float _currentThirst;
    public float ThirstPercent => _currentThirst / _maxThirst;

    [Header("Happiness")]
    [SerializeField] private float _maxHappiness = 100f;
    [SerializeField] private float _happinessDepletionRate = 1f;
    private float _currentHappiness;
    public float HappinessPercent => _currentHappiness / _maxHappiness;

    public GameManagerScript gameManager;

    private bool isDead;

    private void Start()
    {
        _currentHunger = _maxHunger;
        _currentThirst = _maxThirst;
        _currentHappiness = _maxHappiness;
    }

    private void Update()
{
    _currentHunger -= _hungerDepletionRate * Time.deltaTime;
    _currentThirst -= _thirstDepletionRate * Time.deltaTime;
    _currentHappiness -= _happinessDepletionRate * Time.deltaTime;

    // Clamp values so they don't go negative
    _currentHunger = Mathf.Clamp(_currentHunger, 0, _maxHunger);
    _currentThirst = Mathf.Clamp(_currentThirst, 0, _maxThirst);
    _currentHappiness = Mathf.Clamp(_currentHappiness, 0, _maxHappiness);

    if (!isDead && (_currentHunger <= 0 || _currentThirst <= 0 || _currentHappiness <= 0))
    {
        isDead = true;
        if (gameManager != null)
            gameManager.GameOver();
        else
            Debug.LogError("GameManager is not assigned in the Inspector!");
    }

}

    public void ReplenishHungerThirstHappiness(float hungerAmount, float thirstAmount, float happinessAmount)
    {
        _currentHunger += hungerAmount;
        _currentThirst += thirstAmount;
        _currentHappiness += happinessAmount;

        if (_currentHunger > _maxHunger) _currentHunger = _maxHunger;
        if (_currentThirst > _maxThirst) _currentThirst = _maxThirst;
        if (_currentHappiness > _maxHappiness) _currentHappiness = _maxHappiness;
    }

}