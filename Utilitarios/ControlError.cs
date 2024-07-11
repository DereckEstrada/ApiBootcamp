namespace Practica2.Utilitarios
{
    public class ControlError
    {
        public void LogErrorMetodos(string clase, string metodo, string error)
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
                StreamWriter writ = new StreamWriter($"{ruta}\\{archivo}",true);

                writ.WriteLine($"Se presento una novedad en la clase: '{clase}',en el metodo: '{metodo}', con el siguiente error: '{error}'");
                writ.Close(); 
            }
            catch (Exception)
            {

                throw;
            }            
        }
    }
}
