using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComprasApp.Models;
using SQLite;

namespace ComprasApp.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;
        // conexao com o banco de dados
        public SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }
        // inserir um produto novo no banco de dados
        public Task<int> Insert(Produto p)
        {
            return _conn.InsertAsync(p);
        }

        //public Task<List<Produto>> Update (Produto p)
        public Task<int> Update(Produto p)
        {
            /*
            string sql = "UPDATE Produto SET Descricao = ?, Quantidade = ?, Preco = ? WHERE Id = ?";

            return _conn.QueryAsync<Produto>(sql, p.Descricao, p.Quantidade, p.Preco, p.Id);
            */
            return _conn.UpdateAsync(p);
        }
        // Pegar todos os produto dos banco de dados
        public Task<List<Produto>> GetAll()
        {
            return _conn.Table <Produto>().ToListAsync();
        }
        // Deletar um produto pelo ID
        public Task<int> Delete(int id)
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }

        // Buscar algum produto com base em uma string de consulta
        public Task<List<Produto>> Search(string q)
        {
            string sql = "SELECT * FROM Produto WHERE Descricao LIKE '%" + q + "%'";

            return _conn.QueryAsync<Produto>(sql);
        }
    }
}
