namespace Backend.TechChallenge.Domain.Services.Email
{
    public class EmailNormalizer : IEmailNormalizer
    {
        //I haven't change the behavior of this method (just reordering remove and replace due to some unit tests failing),
        // although I think it doesn't make a lot of sense...
        public string Normalize(string email)
        {
            var aux = email.Split('@', StringSplitOptions.RemoveEmptyEntries);

            var plusIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = plusIndex < 0 ? aux[0].Replace(".", "") : aux[0].Remove(plusIndex).Replace(".", "");

            return $"{aux[0]}@{aux[1]}";            
        }
    }
}
