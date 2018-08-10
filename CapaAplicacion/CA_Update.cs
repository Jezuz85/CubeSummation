namespace CapaAplicacion
{
    using CapaDominio;
    using Common;
    using System;

    internal class CA_Update : CD_Requerimientos, ICube
    {
        private int x { get; set; }
        private int y { get; set; }
        private int z { get; set; }
        private int w { get; set; }

        private int dimension { get; set; }

        /// <summary>
        /// Método que ejecuta el query tipo update
        /// </summary>
        public string RealizarConsulta(int[][][] matrix)
        {
            string resp = "";
            if (ValidarRequerimientos())
            {
                matrix[x - 1][y - 1][z - 1] = w;
            }
            else
            {
                resp = MensajeAlgoritmo;
            }

            return resp;
        }

        public CA_Update(string query, int dimension)
        {
            string[] querySplitted = query.Split(' ');
            x = Convert.ToInt32(querySplitted[1]);
            y = Convert.ToInt32(querySplitted[2]);
            z = Convert.ToInt32(querySplitted[3]);
            w = Convert.ToInt32(querySplitted[4]);
            this.dimension = dimension;
        }

        protected bool ValidarRequerimientos()
        {
            return ValidarPosicionInicial(x, 'x') && ValidarPosicionInicial(y, 'y') && ValidarPosicionInicial(z, 'z') && ValidarValoresMaxMin();
        }

        private bool ValidarValoresMaxMin()
        {
            bool resp = W_MIN <= w && w <= W_MAX;
            if (!resp)
            {
                string message = CO_MensajesSistema.ValorActualizar + W_MIN + "y " + W_MAX;
                MensajeAlgoritmo += "- " + (String.IsNullOrEmpty(MensajeAlgoritmo) ? message + Environment.NewLine : message + Environment.NewLine);
            }
            return resp;
        }

        public bool ValidarPosicionInicial(int primerValor, char coordinate)
        {
            bool resp = 1 <= primerValor && primerValor <= dimension;
            if (!resp)
            {
                string message = "La posición inicial de comparación en la coordenada " + coordinate + " es mayor a la final. La posición inicial del primer cubo es (1,1,1)";
                MensajeAlgoritmo += "- " + (String.IsNullOrEmpty(MensajeAlgoritmo) ? message + System.Environment.NewLine : message + System.Environment.NewLine);
            }
            return resp;
        }

        public bool ValidarValoresIniciales(int first, int last, char coordinate)
        {
            throw new NotImplementedException();
        }
    }
}