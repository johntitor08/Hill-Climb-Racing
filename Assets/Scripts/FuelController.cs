using UnityEngine;
using UnityEngine.UI;

public class FuelController : MonoBehaviour
{
    public static FuelController Instance;
    [SerializeField] private Image fuelImage;
    [SerializeField, Range(0.1f, 5)] private float fuelDrainSpeed = 1;
    [SerializeField] private float maxFuelAmount = 100;
    [SerializeField] private Gradient fuelGradient;
    private float currentFuelAmount;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }

    }

    private void Start()
    {
        currentFuelAmount = maxFuelAmount;
        UpdateUI();

    }

    private void Update()
    {
        currentFuelAmount -= Time.deltaTime * fuelDrainSpeed;
        UpdateUI();

    }

    private void UpdateUI()
    {
        fuelImage.fillAmount = currentFuelAmount / maxFuelAmount;
        fuelImage.color = fuelGradient.Evaluate(fuelImage.fillAmount);

    }

}