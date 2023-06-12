/// <summary>
/// Class para joia verde
/// </summary>
public class Green : Jewel
{
    /// <summary>
    /// Construtor com coordenadas separadas
    /// </summary>
    public Green(int x, int y) : base(new Position(x, y)) { }
    /// <summary>
    /// Construtor com coordenada em Position
    /// </summary>
    public Green(Position position) : base(position) { }

    /// <summary>
    /// Representacao em String da entidade
    /// </summary>
    public override string ToString()
    {
        return "JG";
    }

    /// <summary>
    /// Valor da Joia
    /// </summary>
    public override int GetValue()
    {
        return 50;
    }
}