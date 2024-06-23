namespace cadastro_cliente_mvc.Models
{
    public class Cliente
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public FormPaga FormPag { get; set; }

        public string Produto { get; set; }

    }

    public enum FormPaga
    {
        Pix, Credito, Debito
    }


}
