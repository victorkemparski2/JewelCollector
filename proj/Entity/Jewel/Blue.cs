/// <summary>
/// Class para joia azul (note que a classe implementa a interface IRechargeable)
/// </summary>
public class Blue : Jewel, IRechargeable
{
    /// <summary>
    /// Construtor com coordenadas separadas
    /// </summary>
    public Blue(int x, int y) : base(new Position(x, y)) { }

    /// <summary>
    /// Construtor com coordenada em Position
    /// </summary>
    public Blue(Position position) : base(position) { }

    /// <summary>
    /// Representacao em String da entidade
    /// </summary>
    public override string ToString()
    {
        return "JB";
    }

    /// <summary>
    /// Valor da Joia
    /// </summary>
    public override int GetValue()
    {
        return 10;
    }

    /// <summary>
    /// Metodo comum da interface IRechargeable
    /// </summary>
    /// <param name="robot"></param>
    public void Recharge(Robot robot)
    {
        robot.AddHealth(5);
    }
}