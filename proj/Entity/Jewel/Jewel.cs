/// <summary>
/// Classe Abstrata que engloba todos os tipos de joias
/// </summary>
public abstract class Jewel : Entity, ICollectable
{
    /// <summary>
    /// Construtor
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public Jewel(Position position) : base(position) { }

    /// <summary>
    /// Metodo abstrato
    /// </summary>
    /// <returns></returns>
    public abstract int GetValue();

    /// <summary>
    /// Metodo a ser executado quando o robo interage com essa classe
    /// </summary>
    /// <param name="robot"></param>
    public void Collect(Robot robot)
    {
        robot.AddToBag(this);
    }
}