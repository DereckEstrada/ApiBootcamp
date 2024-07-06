namespace Practica2.Utilitarios
{
    public class ControlError
    {
        public void LogErrorMetodos(string metodo, string error)
        {
            var ruta=string.Empty;
            var archivo=string.Empty;
            DateTime date= DateTime.Now;
            try
            {
                ruta = "C:\\ProyectoIntegrador\\Logs";
                archivo=$"Log_{date.ToString("dd-MM-yyyy")}";
                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }
                StreamWriter writer = new StreamWriter($"{ruta}\\{archivo}");
                writer.WriteLine($"Se presento una novedad en el metodo: '{metodo}', con el siguiente error: '{error}'");
                writer.Close();
            }
            catch (Exception)
            {

                throw;
            }            
        }
    }
}
