/// <summary>
/// Classe Abstrata que engloba todas as entidades (tudo que ocupa posicao no mapa)
/// </summary>
public abstract class Entity
{
    /// <summary>
    /// Posicao da entidade
    /// </summary>
    /// <value></value>
    public Position Position { get; protected set; }

    /// <summary>
    /// Construtor
    /// </summary>
    public Entity(Position position)
    {
        Position = new Position(position.X, position.Y);
    }

}
