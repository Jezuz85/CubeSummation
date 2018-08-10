namespace CapaAplicacion
{
    using CapaDominio;
    using Common;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal class CA_CasosPrueba : CD_Requerimientos
    {
        #region variables

        private List<ICube> consultas;
        public int dimension { get; set; }
        public int TamañoConsulta { get; set; }
        private string dimPlusNumQuery { get; set; }
        private int[][][] matrix;

        #endregion variables

        protected bool ValidarDimensiones()
        {
            return (validarMatriz() && RequerimientoMatriz() && RequerimientoTamaño());
        }

        private bool validarMatriz()
        {
            bool resp = Regex.Match(dimPlusNumQuery, @"^[0-9]*\s[0-9]*$").Success;
            if (!resp)
            {
                string message = CO_MensajesSistema.FormatoMatriz;
                MensajeAlgoritmo += "- " + (String.IsNullOrEmpty(MensajeAlgoritmo) ? message + Environment.NewLine : message + Environment.NewLine);
            }
            else
            {
                string[] dimPlusNumQuerySplitted = dimPlusNumQuery.Split(' ');
                dimension = Convert.ToInt32(dimPlusNumQuerySplitted[0]);
                TamañoConsulta = Convert.ToInt32(dimPlusNumQuerySplitted[1]);
            }
            return resp;
        }

        private bool RequerimientoMatriz()
        {
            bool resp = (dimension >= 1 && dimension <= N);
            if (!resp)
            {
                string message = CO_MensajesSistema.TamañoMatriz + N.ToString();
                MensajeAlgoritmo += "- " + (String.IsNullOrEmpty(MensajeAlgoritmo) ? message + Environment.NewLine : message + Environment.NewLine);
            }
            return resp;
        }

        private bool RequerimientoTamaño()
        {
            bool resp = (TamañoConsulta >= 1 && TamañoConsulta <= M);
            if (!resp)
            {
                string message = CO_MensajesSistema.CantidadTest1 + M.ToString();
                MensajeAlgoritmo += "- " + (String.IsNullOrEmpty(MensajeAlgoritmo) ? message + System.Environment.NewLine : message + System.Environment.NewLine);
            }
            return resp;
        }

        public CA_CasosPrueba(string dimPlusNumQuery)
        {
            this.dimPlusNumQuery = dimPlusNumQuery;
            ValidarDimensiones();
            consultas = new List<ICube>();
            matrix = new int[dimension][][];
            for (int i = 0; i < dimension; i++)
            {
                matrix[i] = new int[dimension][];
                for (int j = 0; j < dimension; j++)
                {
                    matrix[i][j] = new int[dimension];
                }
            }
        }

        public string execTest()
        {
            string resp = "";
            foreach (ICube query in consultas)
            {
                resp += query.RealizarConsulta(matrix) + (query is CA_Update ? "" : System.Environment.NewLine);
            }

            return resp;
        }

        public bool AgregarConsultaPrueba(string query)
        {
            bool isUpdate = Regex.Match(query, @"^UPDATE\s[0-9]*\s[0-9]*\s[0-9]*\s[0-9]*$").Success;
            bool isQuery = Regex.Match(query, @"^QUERY\s[0-9]*\s[0-9]*\s[0-9]*\s[0-9]*\s[0-9]*\s-?[0-9]*$").Success;
            bool resp = isUpdate || isQuery;
            if (!resp)
            {
                string message = CO_MensajesSistema.FormatoQuery;
                MensajeAlgoritmo += "- " + (String.IsNullOrEmpty(MensajeAlgoritmo) ? message : System.Environment.NewLine + message);
            }
            else
            {
                ICube q = null;
                if (isQuery)
                {
                    q = new CA_Operacion(query, dimension);
                }
                else
                {
                    q = new CA_Update(query, dimension);
                }

                consultas.Add(q);
            }
            return resp;
        }
    }
}