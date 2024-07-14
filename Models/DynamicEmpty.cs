namespace Practica2.Models
{
    public  class DynamicEmpty
    {
        //recibe cualquier objeto de ser null o una lista vacia devulve true
        public bool IsDynamicEmpty(dynamic obj)
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
