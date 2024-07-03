namespace Practica2.Models
{
    public  class DynamicEmpty
    {
        public static bool IsDynamicEmpty(dynamic obj)
        {
            if (obj is IEnumerable<dynamic> list)
            {
                return !list.Any();
            } else if (obj==null)
            {
                return true;
            }
            return false;
            }
    }
}
