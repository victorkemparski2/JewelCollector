/// <summary>
/// Classe para Agua
/// </summary>
public class Water : Obstacle
{
    /// <summary>
    /// Construtor com coordenada em Position
    /// </summary>
    public Water(int x, int y) : base(new Position(x, y)) { }

    /// <summary>
    /// Construtor com coordenada em Position
    /// </summary>
    public Water(Position position) : base(position) { }

    /// <summary>
    /// Representacao em String da entidade
    /// </summary>
    public override string ToString()
    {
        return "##";
    }

}