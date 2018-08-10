namespace CapaAplicacion
{
    using CapaDominio;
    using System;

    public class CA_Operacion : CD_Requerimientos, ICube
    {
        #region variables

        public int dimension { get; set; }
        public int x1 { get; set; }
        public int x2 { get; set; }
        public int y1 { get; set; }
        public int y2 { get; set; }
        public int z1 { get; set; }
        public int z2 { get; set; }

        #endregion variables

        #region metodos

        /// <summary>
        /// Método que realiza el query
        /// </summary>
        public string RealizarConsulta(int[][][] matrix)
        {
            if (ChequearValoresMatriz())
            {
                int suma = 0;

                for (int i = x1 - 1; i < x2; i++)
                {
                    for (int j = y1 - 1; j < y2; j++)
                    {
                        for (int k = z1 - 1; k < z2; k++)
                        {
                            suma += matrix[i][j][k];
                        }
                    }
                }

                return suma.ToString();
            }
            else
            {
                return MensajeAlgoritmo;
            }
        }

        protected bool ChequearValoresMatriz()
        {
            if (ValidarValoresIniciales(x1, x2, 'x') && ValidarValoresIniciales(y1, y2, 'y') && ValidarValoresIniciales(z1, z2, 'z'))
            {
                return true;
            }
            return false;
        }

        public bool ValidarValoresIniciales(int primerValor, int segundoValor, char coordinate)
        {
            bool bValor = 1 <= primerValor && primerValor <= segundoValor && segundoValor <= dimension;

            if (!bValor)
            {
                string message = "La posición inicial de comparación en la coordenada " + coordinate + " es mayor a la final. La posición inicial del primer cubo es (1,1,1)";
                MensajeAlgoritmo += "- " + (String.IsNullOrEmpty(MensajeAlgoritmo) ? message + Environment.NewLine : message + System.Environment.NewLine);
            }
            return bValor;
        }

        public CA_Operacion(string query, int dimension)
        {
            string[] querysplitted = query.Split(' ');
            x1 = Convert.ToInt32(querysplitted[1]);
            y1 = Convert.ToInt32(querysplitted[2]);
            z1 = Convert.ToInt32(querysplitted[3]);
            x2 = Convert.ToInt32(querysplitted[4]);
            y2 = Convert.ToInt32(querysplitted[5]);
            z2 = Convert.ToInt32(querysplitted[6]);
            this.dimension = dimension;
        }

        #endregion metodos
    }
}