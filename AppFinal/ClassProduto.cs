using System;
using System.Collections.Generic;
using System.IO;
using Mono.Data.Sqlite;
using System.Data;

namespace AppFinal{
	public class ClassProduto
	{


		public static string db_file;
		private SqliteConnection conn;
		//private classDBCFG pegaCFG = new classDBCFG();

		public ClassProduto(){


			conn = GetConnection ();

			GetConnection ();
			createProduto ();
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

		public void createProduto ()
		{
			// cria a tabela se a mesma nao existe e jah popula ela com dados basicos
			var sql =	"CREATE TABLE " +
						"IF NOT EXISTS PRODUTOS " +
								"(ID_PRODUTO INTEGER PRIMARY KEY AUTOINCREMENT," +
								"DESCRICAO VARCHAR( 100 ), " +
								"ID_QTD INT NOT NULL, " +
								"ID_VALOR INT NOT NULL);";
			using (this.conn) {
				conn.Open ();

				using (var cmd = conn.CreateCommand ()) {
					cmd.CommandText = sql;
					cmd.ExecuteNonQuery ();

				}

			}
		}



		public void saveProdutos(int id_produto, string descricao, int id_qtd, int id_valor ){

			using (this.conn) {
				conn.Open ();

				using (var cmd = conn.CreateCommand ()) {
					if (id_produto < 1) {
						// Do an insert
						//Console.WriteLine (descricao);
						//Console.WriteLine (regiao);
						cmd.CommandText =   "INSERT INTO PRODUTOS " +
							"(DESCRICAO, ID_QTD, ID_VALOR)" +
											" VALUES " +
														"(@descricao, @id_qtdes, @id_valor);" +
											" SELECT last_insert_rowid();";

						cmd.Parameters.AddWithValue ("@descricao", descricao);
						cmd.Parameters.AddWithValue ("@id_qtdes", id_qtd);
						cmd.Parameters.AddWithValue ("@id_valor", id_valor);

						//Console.WriteLine ("se fodeo");
						cmd.ExecuteNonQuery ();

					} else {
						// Do an update
						cmd.CommandText = "UPDATE PRODUTOS " +
													"SET" +
							" DESCRICAO = @DESCRICAO, ID_QTD = @id_qtdes, ID_VALOR = @id_valor";
						cmd.Parameters.AddWithValue ("@descricao", descricao);
						cmd.Parameters.AddWithValue ("@id_qtdes", id_qtd);
						cmd.Parameters.AddWithValue ("@id_valor", id_valor);

						//Console.WriteLine ("se fodeo");
						cmd.ExecuteNonQuery ();
					}
				}
			}
		}

		public void deleteProduto (int idProduto)
		{
			var sql = string.Format ("DELETE FROM PRODUTOS WHERE ID_PRODUTO = {0};", idProduto);

			using (this.conn) {
				conn.Open ();

				using (var cmd = conn.CreateCommand ()) {
					cmd.CommandText = sql;
					cmd.ExecuteNonQuery ();
				}
			}
		}



		//		public  getProduto (int id)
		//		{
		//			var sql = string.Format ("select Produtos.*, P.DESCRICAO, U.DESCRICAO, T.DESCRICAO, P.CODIGO_PAIS from Produtos join PAISES P ON(P.id_qtdES = ProdutoS.id_qtdES) join testeS U ON(U.ID_teste = ProdutoS.ID_teste) join valorS T ON(T.ID_valor = ProdutoS.ID_valor) WHERE id_produto = {0};", id);
		//
		//			using (this.conn) {
		//				conn.Open ();
		//
		//				using (var cmd = conn.CreateCommand ()) {
		//					cmd.CommandText = sql;
		//
		//					using (var reader = cmd.ExecuteReader ()) {
		//						if (reader.Read ())
		//							return new objectProduto (reader.GetInt32(0),reader.GetString(1),reader.GetInt32(2),reader.GetInt32(3), reader.GetInt32(4),reader.GetString(5),reader.GetString(6),reader.GetString(7),reader.GetString(8),reader.GetFloat(9),reader.GetString(10),reader.GetString(11),reader.GetString(12),reader.GetString(13),reader.GetString(14),reader.GetString(15),reader.GetString(16),reader.GetString(17),reader.GetString(18),reader.GetString(19),reader.GetString(20),reader.GetFloat(21),reader.GetFloat(22),reader.GetBoolean(23),reader.GetBoolean(24),reader.GetString(25),reader.GetString(26),reader.GetString(27), reader.GetInt32 (28)); 
		//						else
		//							return null;
		//					}
		//				}
		//			}
		//		}


		public ObjetoProduto getVinho2 ()
		{
			var sql = string.Format ("select ID_PRODUTO, DESCRICAO, ID_QTD, ID_VALOR from produto");

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

							return new ObjetoProduto (reader.GetInt32(0),reader.GetString(1),reader.GetInt32(2),reader.GetInt32(3)); 
						}
						else
							return null;
					}
				}
			}
		}

	}
}


