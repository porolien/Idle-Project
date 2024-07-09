using System.Diagnostics;
using System.Threading.Tasks;

public class Hosiptal : Building
{
    private int healRate;
    public override async Task BuildingTask(EntityMain _entity)
    {
        while (_entity.Stat.Hp < _entity.Stat.MaxHp)
        {
            await Task.Delay(1000);
            _entity.Stat.Hp += healRate;
            _entity.TESTHP();
            if (_entity.Stat.Hp > _entity.Stat.MaxHp)
            {
                _entity.Stat.Hp = _entity.Stat.MaxHp;
            }
        }
    }

    protected override void Start()
    {
        healRate = 1;
    }
}
