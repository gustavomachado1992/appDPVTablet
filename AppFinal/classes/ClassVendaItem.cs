using System;
using System.Collections.Generic;
using System.IO;
using Mono.Data.Sqlite;
using System.Data;

namespace AppFinal
{
		
	public class ClassVendaItem  

	{
	public static string db_file;
	private SqliteConnection conn;
	//private classDBCFG pegaCFG = new classDBCFG();

		public ClassVendaItem(){


		conn = GetConnection ();

		GetConnection ();
			createVendaItem ();
	}

	public static SqliteConnection GetConnection ()
	{

		var dbPath = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.Personal), db_file);
		bool exists = File.Exists (dbPath);

		if (!exists)
			SqliteConnection.CreateFile (dbPath);

		var conn = new SqliteConnection ("Data Source=" + dbPath);
		return conn;


	}

	public void createVendaItem ()
	{
		// cria a tabela se a mesma nao existe e jah popula ela com dados basicos
			var sql =	"CREATE TABLE " +
				"IF NOT EXISTS VENDA_ITEM " +
			"(ID_VENDA_ITEM INTEGER PRIMARY KEY AUTOINCREMENT," +
			"PRODUTO_VENDA_ITEM INTEGER( 11 ), " +
			"VENDA_VENDA_ITEM INTEGER( 11 ), " +
			"QTD INT NOT NULL, " +
				"VALOR INT NOT NULL, " +
				"DATA_CAD DATETIME" +
				"FOREIGN KEY(PRODUTO_VENDA_ITEM) REFERENCES PRODUTOS" +
				"FOREIGN KEY(VENDA_VENDA_ITEM) REFERENCES VENDAS" +
				");";
		







			using (this.conn) {
			conn.Open ();

			using (var cmd = conn.CreateCommand ()) {
				cmd.CommandText = sql;
				cmd.ExecuteNonQuery ();

			}

		}
	}



		public void saveProdutos(int id_vendaItem, int produto_vendaItem, int venda_vendaItem, int qtd, int id_valor ){

		using (this.conn) {
			conn.Open ();

			using (var cmd = conn.CreateCommand ()) {
					if (id_vendaItem < 1) {
					// Do an insert
					//Console.WriteLine (descricao);
					//Console.WriteLine (regiao);
						cmd.CommandText =   "INSERT INTO VENDA_ITEM " +
							"(PRODUTO_VENDA_ITEM, VENDA_VENDA_ITEM, QTD, VALOR, DATA_CAD)" +
						" VALUES " +
							"(@produto_vendaItem, @venda_VndaItem, @qtd, @valor, NOW());" +
						" SELECT last_insert_rowid();";

					cmd.Parameters.AddWithValue ("@produto_vendaItem", produto_vendaItem);
					cmd.Parameters.AddWithValue ("@venda_VndaItem", venda_vendaItem);
						cmd.Parameters.AddWithValue ("@qtd", qtd);
						cmd.Parameters.AddWithValue ("@valor", id_valor);

					//Console.WriteLine ("se fodeo");
					cmd.ExecuteNonQuery ();

				} else {
					// Do an update
						cmd.CommandText = "UPDATE VENDA_ITEM " +
						"SET" +
							" VENDA_VENDA_ITEM = @venda_VndaItem, PRODUTO_VENDA_ITEM = @produto_vendaItem, QTD = @qtd, VALOR = @valor";

						cmd.Parameters.AddWithValue ("@produto_vendaItem", produto_vendaItem);
						cmd.Parameters.AddWithValue ("@venda_VndaItem", venda_vendaItem);
						cmd.Parameters.AddWithValue ("@qtd", qtd);
						cmd.Parameters.AddWithValue ("@valor", id_valor);


					//Console.WriteLine ("se fodeo");
					cmd.ExecuteNonQuery ();
				}
			}
		}
	}

		public void deleteProduto (int id_vendaItem)
	{
			var sql = string.Format ("DELETE FROM VENDA_ITEM WHERE ID_COD = {0};", id_vendaItem);

		using (this.conn) {
			conn.Open ();

			using (var cmd = conn.CreateCommand ()) {
				cmd.CommandText = sql;
				cmd.ExecuteNonQuery ();
			}
		}
	}
	


		public ObjetoVendaItem getProduto (int id_vendaItem)
			{
			var sql = string.Format ("select P.ID_PRODUTO, P.DESCRICAO, V.ID_QTD, P.ID_VALOR, U.TOTAL  from VENDA_ITEM V join PRODUTO P ON(P.ID_PRODUTO = V.PRODUTO_VENDA_ITEM) join VENDAS U ON(U.ID_COD = V.VENDA_VENDA_ITEM)  WHERE ID_VENDA_ITEM = {0};", id_vendaItem);
	
				using (this.conn) {
					conn.Open ();
	
					using (var cmd = conn.CreateCommand ()) {
						cmd.CommandText = sql;
	
						using (var reader = cmd.ExecuteReader ()) {
							if (reader.Read ())
							return new ObjetoVendaItem (reader.GetInt32(0),reader.GetString(1),reader.GetInt32(2),reader.GetInt32(3), reader.GetInt32(4),reader.GetDateTime(5)); 
							else
								return null;
						}
					}
				}
			}


		public ObjetoVendaItem getVinho2 ()
	{
			var sql = string.Format ("select * from VENDA_ITEM");

		using (this.conn) {
			conn.Open ();

			using (var cmd = conn.CreateCommand ()) {
				cmd.CommandText = sql;

				using (var reader = cmd.ExecuteReader ()) {
					if (reader.Read ()){
							Console.WriteLine (reader.GetInt32 (0));
							Console.WriteLine (reader.GetString (1));
							Console.WriteLine (reader.GetInt32 (2));
							Console.WriteLine (reader.GetInt32 (3));
							Console.WriteLine (reader.GetInt32 (4));
							Console.WriteLine (reader.GetInt32 (5));

							return new ObjetoVendaItem (reader.GetInt32(0),reader.GetInt32(1),reader.GetInt32(2),reader.GetInt32(3),reader.GetInt32(4),reader.GetDateTime(5)); 
					}
					else
						return null;
				}
			}
		}
	}

}
}



