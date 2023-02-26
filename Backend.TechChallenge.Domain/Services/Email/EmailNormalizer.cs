namespace Backend.TechChallenge.Domain.Services.Email
{
    public class EmailNormalizer : IEmailNormalizer
    {
        public string Normalize(string email)
        {
            var aux = email.Split('@', StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            return $"{aux[0]}@{aux[1]}";            
        }
    }
}
