namespace CapaDominio
{
    public interface ICube
    {
        bool ValidarValoresIniciales(int first, int last, char coordinate);

        string RealizarConsulta(int[][][] matrix);
    }
}