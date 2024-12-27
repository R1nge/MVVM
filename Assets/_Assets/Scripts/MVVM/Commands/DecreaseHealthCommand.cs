using _Assets.Scripts.MVVM.Models;

namespace _Assets.Scripts.MVVM.Commands
{
    public class DecreaseHealthCommand : ICommand
    {
        private readonly HealthModel _healthModel;

        public DecreaseHealthCommand(HealthModel healthModel) => _healthModel = healthModel;

        public void Execute() => _healthModel.DecreaseHealth(1);

        public void Undo() => _healthModel.IncreaseHealth(1);
    }
}