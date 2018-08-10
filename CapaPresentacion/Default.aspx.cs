namespace CapaPresentacion
{
    using CapaAplicacion;
    using System;
    using System.Web.UI;

    public partial class Default : Page
    {
        /// <summary>
        /// evento del botón Ejecutar
        /// </summary>
        protected void RealizarCalculo(object sender, EventArgs e)
        {
            CA_Principal mainprogram = new CA_Principal(txb_Entrada.Text);
            txb_Salida.Text = mainprogram.Execute().Replace(@"\r\n\r\n", @"\r\n");
        }
    }
}