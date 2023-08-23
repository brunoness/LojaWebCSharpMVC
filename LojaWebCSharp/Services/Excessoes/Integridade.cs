namespace LojaWebCSharp.Services.Excessoes {
    public class Integridade : ApplicationException {
        public Integridade(string messege) : base(messege) {
        }
    }
}
