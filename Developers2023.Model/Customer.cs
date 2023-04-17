namespace Developers2023.Model
{
    /// <summary>
    /// Dane klienta
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nazwa
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Adres e-mail
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Numer telefonu
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Adres domowy
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Numer PESEL
        /// </summary>
        public string PESEL { get; set; }
    }
}
