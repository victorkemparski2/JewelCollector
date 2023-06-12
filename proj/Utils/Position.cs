
/// <summary>
/// Classe utilitario para um jogo bidimensional
/// </summary>
public class Position
{
    /// <summary>
    /// Coordenada X
    /// </summary>
    /// <value></value>
    public int X { get; }

    /// <summary>
    /// Coordenada X
    /// </summary>
    /// <value></value>
    public int Y { get; }

    /// <summary>
    /// Construtor
    /// </summary>
    /// <param name="x">Coordenada X</param>
    /// <param name="y">Coordenada Y</param>
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    /// Soma de duas posicoes
    /// </summary>
    /// <value></value>
    public static Position operator +(Position a, Position b)
    {
        return new Position(a.X + b.X, a.Y + b.Y);
    }

    /// <summary>
    /// Enumeravel que itera por todas as posicoes em volta
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Position> GetNearby()
    {
        yield return new Position(X + 0, Y - 1);
        yield return new Position(X - 1, Y + 0);
        yield return new Position(X + 0, Y + 1);
        yield return new Position(X + 1, Y + 0);
    }

    /// <summary>
    /// Itera por todas as posicoes em um array bidimensional
    /// </summary>
    /// <param name="width">Largura do array</param>
    /// <param name="height">Altura do array</param>
    /// <returns>Uma tupla com a posicao e um string para a funcao de print</returns>
    public static IEnumerable<(Position, string)> LoopAll(int width, int height)
    {

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                yield return (new Position(j, i), j == width - 1 ? "\n" : " ");
            }
        }
    }


}