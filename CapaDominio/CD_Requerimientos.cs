namespace CapaDominio
{
    public abstract class CD_Requerimientos
    {
        /// <summary>
        /// Cantidad máxima de operaciones
        /// </summary>
        protected const int M = 1000;

        /// <summary>
        /// Tamaño máximo de la matriz
        /// </summary>
        protected const int N = 100;

        /// <summary>
        /// numero de pruebas permitidas
        /// </summary>
        protected const int T = 50;

        /// <summary>
        /// Mínimo valor de una coordenada
        /// </summary>
        protected const int W_MIN = -1000000000;

        /// <summary>
        /// Máximo valor de una coordenada
        /// </summary>
        protected const int W_MAX = 1000000000;

        /// <summary>
        /// Corresponde al mensaje cuando no se cumple una restricción del algoritmo
        /// </summary>
        public string MensajeAlgoritmo = string.Empty;
    }
}