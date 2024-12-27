using _Assets.Scripts.MVVM.Models;

namespace _Assets.Scripts.MVVM.Commands
{
    public class IncreaseHealthCommand : ICommand
    {
        private readonly HealthModel _healthModel;

        public IncreaseHealthCommand(HealthModel healthModel) => _healthModel = healthModel;

        public void Execute() => _healthModel.IncreaseHealth(1);

        public void Undo() => _healthModel.DecreaseHealth(1);
    }
}