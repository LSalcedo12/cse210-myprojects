using System.Runtime;

public class ChecklistGoal : Goal
{
    private int _amountComplete;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountComplete = 0;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (_amountComplete < _target)
        {
            _amountComplete++;
        }
    }

    public override bool IsComplete() => _amountComplete >= _target;

    public override string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {GetShortName()}, ({GetDescription()}) -- Currently completed: {_amountComplete}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal: {GetShortName()}, {GetDescription()}, {GetPoints()}, {_bonus}, {_target}, {_amountComplete}";
    }
}