using System;
using System.Collections.Generic;
using System.IO;
using Mono.Data.Sqlite;
using System.Data;


namespace AppFinal
{
		
	public class ClasseLoja 

		{


			public static string db_file;
			private SqliteConnection conn;
			//private classDBCFG pegaCFG = new classDBCFG();

		public ClasseLoja(){


				conn = GetConnection ();

				GetConnection ();
			createLoja ();
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

			public void createLoja ()
			{
				// cria a tabela se a mesma nao existe e jah popula ela com dados basicos
			var sql ="CREATE TABLE LOJA" +
				"IF NOT EXISTS LOJA " +
					"(COD INTEGER PRIMARY KEY AUTOINCREMENT," +
					"RAZAO VARCHAR( 50 ), " +
				    "FANTASIA VARCHAR( 50 ), " +
				    "CNPJ VARCHAR( 50 ), " +
					"ENDERECO VARCHAR( 50 ), " +
					"CIDADE VARCHAR( 30 ), " +
					"UF VARCHAR( 02 ), " +
					"DATA_CAD DATETIME, " +
					");";
				using (this.conn) {
					conn.Open ();

					using (var cmd = conn.CreateCommand ()) {
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery ();

					}

				}
			}



		public void saveProdutos(int id_loja, string razao,string fantasia,string cnpj,string endereco,string cidade,string uf ){

				using (this.conn) {
					conn.Open ();

					using (var cmd = conn.CreateCommand ()) {
					if (id_loja < 1) {
							// Do an insert
							//Console.WriteLine (descricao);
							//Console.WriteLine (regiao);
						cmd.CommandText =   "INSERT INTO LOJA " +
								"(RAZAO, FANTASIA, CNPJ, ENDERECO, CIDADE, UF, DATA_CAD)" +
								" VALUES " +
							"(@razao,@fantasia,@cnpj,@endereco, @cidade, @uf, NOW());" +
								" SELECT last_insert_rowid();";

						cmd.Parameters.AddWithValue ("@razao", razao );
						cmd.Parameters.AddWithValue ("@fantasia", fantasia);
						cmd.Parameters.AddWithValue ("@cnpj", cnpj);
						cmd.Parameters.AddWithValue ("@endereco", endereco);
						cmd.Parameters.AddWithValue ("@cidade", cidade);
						cmd.Parameters.AddWithValue ("@uf", uf );
							

							//Console.WriteLine ("se fodeo");
							cmd.ExecuteNonQuery ();

						} else {
							// Do an update
						cmd.CommandText = "UPDATE LOJA " +
								"SET" +
							" RAZAO = @razao,FANTASIA = @fantasia,CNPJ = @cnpj,ENDERECO = @endereco,CIDADE = @cidade, UF = @uf, DATA_CAD = NOW";

						cmd.Parameters.AddWithValue ("@razao", razao);
						cmd.Parameters.AddWithValue ("@fantasia", fantasia );
						cmd.Parameters.AddWithValue ("@cnpj", cnpj);
						cmd.Parameters.AddWithValue ("@endereco", endereco);
						cmd.Parameters.AddWithValue ("@cidade", cidade);
						cmd.Parameters.AddWithValue ("@uf", uf);


							//Console.WriteLine ("se fodeo");
							cmd.ExecuteNonQuery ();
						}
					}
				}
			}

			public void deleteProduto (int idLoja)
			{
			var sql = string.Format ("DELETE FROM LOJA WHERE COD = {0};", idLoja);

				using (this.conn) {
					conn.Open ();

					using (var cmd = conn.CreateCommand ()) {
						cmd.CommandText = sql;
						cmd.ExecuteNonQuery ();
					}
				}
			}



//					public  getProduto (int id)
//					{
//						var sql = string.Format ("select from join PAISES P ON(P.id_qtdES = ProdutoS.id_qtdES) join testeS U ON(U.ID_teste = ProdutoS.ID_teste) join valorS T ON(T.ID_valor = ProdutoS.ID_valor) WHERE id_produto = {0};", id);
//			
//						using (this.conn) {
//							conn.Open ();
//			
//							using (var cmd = conn.CreateCommand ()) {
//								cmd.CommandText = sql;
//			
//								using (var reader = cmd.ExecuteReader ()) {
//									if (reader.Read ())
//										return new objectProduto (reader.GetInt32(0),reader.GetString(1),reader.GetInt32(2),reader.GetInt32(3), reader.GetInt32(4),reader.GetString(5),reader.GetString(6),reader.GetString(7),reader.GetString(8),reader.GetFloat(9),reader.GetString(10),reader.GetString(11),reader.GetString(12),reader.GetString(13),reader.GetString(14),reader.GetString(15),reader.GetString(16),reader.GetString(17),reader.GetString(18),reader.GetString(19),reader.GetString(20),reader.GetFloat(21),reader.GetFloat(22),reader.GetBoolean(23),reader.GetBoolean(24),reader.GetString(25),reader.GetString(26),reader.GetString(27), reader.GetInt32 (28)); 
//									else
//										return null;
//								}
//							}
//						}
//					}


		public ObjetoLoja getVinho2 ()
			{
			var sql = string.Format ("select * from LOJA");

				using (this.conn) {
					conn.Open ();

					using (var cmd = conn.CreateCommand ()) {
						cmd.CommandText = sql;

						using (var reader = cmd.ExecuteReader ()) {
							if (reader.Read ()){
								

							return new ObjetoLoja (reader.GetInt32(0),reader.GetString(1),reader.GetString(2),reader.GetString(3),reader.GetString(4),reader.GetString(5),reader.GetString(6),reader.GetDateTime(7)); 
							}
							else
								return null;
						}
					}
				}
			}

		}
	}

