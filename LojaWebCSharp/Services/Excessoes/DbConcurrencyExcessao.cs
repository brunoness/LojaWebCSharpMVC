namespace LojaWebCSharp.Services.Excessoes {
    public class DbConcurrencyExcessao : ApplicationException {
        public DbConcurrencyExcessao(string messege) : base(messege) {

        }
    }
}
