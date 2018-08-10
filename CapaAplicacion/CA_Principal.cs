namespace CapaAplicacion
{
    using CapaDominio;
    using Common;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class CA_Principal : CD_Requerimientos
    {
        #region variables

        private List<CA_CasosPrueba> PruebasList;
        private int TamañoTest { get; set; }
        private string program { get; set; }
        private string[] mainProgram;

        #endregion variables

        #region metodos

        public CA_Principal(string program)
        {
            this.program = program.Replace(Environment.NewLine, "|");
            mainProgram = this.program.Split(Convert.ToChar("|"));
            MensajeAlgoritmo = string.Empty;
            PruebasList = new List<CA_CasosPrueba>();
        }

        public bool ValidarREquerimientos()
        {
            return (ValidarValorT() && ValidarLongitudMinima() && ValidarCasosPrueba());
        }

        private bool ValidarValorT()
        {
            bool resp = Regex.Match(mainProgram[0], @"^[0-9]*$").Success;
            if (!resp)
            {
                string message = CO_MensajesSistema.PrimeraLineaNumerica;
                MensajeAlgoritmo += "- " + (String.IsNullOrEmpty(MensajeAlgoritmo) ? message + System.Environment.NewLine : message + System.Environment.NewLine);
            }
            else
            {
                TamañoTest = Convert.ToInt32(mainProgram[0]);
            }

            return resp;
        }

        private bool ValidarLongitudMinima()
        {
            bool resp = mainProgram.Length >= 3;
            if (!resp)
            {
                string message = CO_MensajesSistema.AlMenos3Lineas;
                MensajeAlgoritmo += "- " + (String.IsNullOrEmpty(MensajeAlgoritmo) ? message + System.Environment.NewLine : message + System.Environment.NewLine);
            }
            return resp;
        }

        private bool ValidarCasosPrueba()
        {
            bool resp = (TamañoTest >= 1 && TamañoTest <= T);
            if (!resp)
            {
                string message = CO_MensajesSistema.CantidadTest + T.ToString();
                MensajeAlgoritmo += "- " + (String.IsNullOrEmpty(MensajeAlgoritmo) ? message + Environment.NewLine : message + Environment.NewLine);
            }
            return resp;
        }

        public string Execute()
        {
            string resultado = string.Empty;

            if (!ValidarREquerimientos())
            {
                resultado = MensajeAlgoritmo;
            }
            else
            {
                int linea = 1, i = 1;

                bool bEjecucion = true;

                while (bEjecucion && i <= TamañoTest)
                {
                    CA_CasosPrueba tc = new CA_CasosPrueba(mainProgram[linea]);
                    bool bError = !String.IsNullOrEmpty(tc.MensajeAlgoritmo);
                    bool outOfLines = mainProgram.Length < linea + tc.TamañoConsulta + 1;

                    if (bError || outOfLines)
                    {
                        ExcepcionConsulta();
                        resultado = bError ? tc.MensajeAlgoritmo : MensajeAlgoritmo;
                        bEjecucion = false;
                    }
                    int j = 1;
                    while (bEjecucion && j <= tc.TamañoConsulta)
                    {
                        if (!tc.AgregarConsultaPrueba(mainProgram[linea + j]))
                        {
                            resultado = tc.MensajeAlgoritmo;
                            bEjecucion = false;
                        }
                        j++;
                    }
                    PruebasList.Add(tc);
                    linea += tc.TamañoConsulta + 1;
                    i++;
                }
                if (bEjecucion)
                {
                    foreach (CA_CasosPrueba tc in PruebasList)
                    {
                        resultado += tc.execTest();
                    }
                }
            }
            return resultado;
        }

        private void ExcepcionConsulta()
        {
            string message = CO_MensajesSistema.ExcepcionConsulta;
            MensajeAlgoritmo += "- " + (String.IsNullOrEmpty(MensajeAlgoritmo) ? message + Environment.NewLine : message + Environment.NewLine);
        }

        #endregion metodos
    }
}