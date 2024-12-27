MVVM

view - has a reference to the VM, interacts with it using commands, is updated by the VM using events

view model - has a reference to the model or has it as a part of itself, subs to the model events.
have commands

model - data to show, events to notify the VM

commands - public and exist in the VM, view sends them



```cs
public class HealthView : MonoBehaviour  
{  
	[SerializeField] private TextMeshProUGUI health;  
	[Inject] private HealthViewModel _healthViewModel;  
  
	private void Awake()  
	{  
		_healthViewModel.OnHealthChanged += UpdateHealth;  
		UpdateHealth(_healthViewModel.Health);  
	}  
  
	private void UpdateHealth(int health)  
	{  
		this.health.text = health.ToString();  
	}  
  
	private void Update()  
	{  
		if (Input.GetMouseButtonDown(0))  
		{  
			_healthViewModel.DecreaseHealthCommand.Execute();  
		}  
  
		if (Input.GetMouseButtonDown(1))  
		{  
			_healthViewModel.IncreaseHealthCommand.Execute();  
		}  
	}
}
```

```cs
public class HealthViewModel : IInitializable, IDisposable  
{  
	private HealthModel _model;  
	public ICommand IncreaseHealthCommand;  
	public event Action<int> OnHealthChanged;  
  
	public int Health => _model.Health;  
  
	private void HealthChanged(int health) => OnHealthChanged?.Invoke(health);  
  
	public void Initialize()  
	{  
		_model = new HealthModel(100, 100);  
		_model.OnHealthChanged += HealthChanged;  
		IncreaseHealthCommand = new IncreaseHealthCommand(_model);  
	}  
  
	public void Dispose() => _model.OnHealthChanged -= HealthChanged;  
}
```

```cs
[Serializable]  
public class HealthModel  
{  
	public HealthModel(int health)  
	{  
		_health = health;  
	}  
  
	private int _health;  
  
	public int Health  
	{  
		get => _health;  
		set  
		{  
			_health = value;  
			OnHealthChanged?.Invoke(_health);  
		}  
	}  
  
	public event Action<int> OnHealthChanged;
	
	public void IncreaseHealth(int amount)  
	{  
		Health += amount;  
	}
}
```

```cs
public class IncreaseHealthCommand : ICommand  
{  
	private readonly HealthModel _healthModel;  
  
	public IncreaseHealthCommand(HealthModel healthModel) 
	{
		 _healthModel = healthModel;
	}  
  
	public void Execute() => _healthModel.IncreaseHealth(1);  
  
	public void Undo() => _healthModel.DecreaseHealth(1);  
}
```


