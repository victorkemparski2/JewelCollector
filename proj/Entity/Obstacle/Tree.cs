/// <summary>
/// Classe para Arvore (O robo consegue recarregar aqui)
/// </summary>
public class Tree : Obstacle, IRechargeable
{
    /// <summary>
    /// Construtor com coordenada em Position
    /// </summary>
    public Tree(int x, int y) : base(new Position(x, y)) { }

    /// <summary>
    /// Construtor com coordenada em Position
    /// </summary>
    public Tree(Position position) : base(position) { }

    /// <summary>
    /// Representacao em String da entidade
    /// </summary>
    public override string ToString()
    {
        return "$$";
    }


    /// <summary>
    /// Metodo comum da interface IRechargeable
    /// </summary>
    /// <param name="robot"></param>
    public void Recharge(Robot robot)
    {
        robot.AddHealth(3);
    }

}