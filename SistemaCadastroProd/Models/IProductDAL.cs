namespace SistemaCadastroProd.Models
{
    public interface IProductDAL
    {
        IEnumerable<Produto> GetAllProdutos();
        void AddProduto(Produto produto);
        void UpdateProduto(Produto produto);
        Produto GetProduto(int? id);
        void DeleteProduto(int? id);
    }
}
