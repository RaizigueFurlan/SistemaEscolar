using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Escola_atv
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void cb_Estado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
}

            private void Button_Click(object sender, RoutedEventArgs e)
            {
                string nomeFantasia = tb_nome.Text;
                string razaoSocial = tb_razaosocial.Text;
                string cnpj  = tb_cnpj.Text;
                string inscEstadual = tb_inscestadual.Text;
                string tipo = "Privada";
                string dateCriacao = tb_data.Text;
                string responsavelEsc = tb_responsave.Text;  
                string telefoneRespon = tb_res_telefo.Text;   
                string email = tb_email.Text;   
                string telefone = tb_telefone.Text;  
                string rua = tb_rua.Text;
                string numero = tb_numerocasa.Text;
                string bairro = tb_bairro.Text;
                string comple = tb_comple.Text;
                string ceo = tb_cep.Text;   
                string cidade = tb_Cidade.Text;
                string estado = cb_Estado.Text;
                 
             

            var data_criacao = tb_data.SelectedDate?.ToString("yyyy-mm-dd"); 


                if ((bool)ra_publi.IsChecked)
                    tipo = " Publica";

                var conecao = new MySqlConnection("server=Localhost;database=Bd_Escola;port=3360;password=root");
                try
                {
                    conecao.Open(); 
                    var comando = conecao.CreateCommand();  

                    comando.CommandText = "insert into Escola values(null, @nome, @razão, @cnpj," + 
                     "@incEstad, @tipo, @data, @resoponvel, @telefoRespon, @email, @telefone, @rua,"+
                      " @numero, @bairro, @complemento, @cep, @cidade, @estado); " ;

                comando.Parameters.AddWithValue("null", null);
                comando.Parameters.AddWithValue("@nome", nomeFantasia);
                comando.Parameters.AddWithValue("@razão", razaoSocial);
                comando.Parameters.AddWithValue("@cnpj", cnpj);
                comando.Parameters.AddWithValue("@incEstad", inscEstadual);
                comando.Parameters.AddWithValue("@tipo", tipo);
                comando.Parameters.AddWithValue("@data", dateCriacao);
                comando.Parameters.AddWithValue("@resposavel", responsavelEsc);
                comando.Parameters.AddWithValue("@telefoRespon", telefoneRespon);
                comando.Parameters.AddWithValue("@email", email);
                comando.Parameters.AddWithValue("@telefone", telefone);
                comando.Parameters.AddWithValue("@rua", rua);
                comando.Parameters.AddWithValue("@numero", numero);
                comando.Parameters.AddWithValue("@bairro", bairro);
                comando.Parameters.AddWithValue("@complemento", comple);
                comando.Parameters.AddWithValue("@cep", ceo);
                comando.Parameters.AddWithValue("@cidade", cidade);
                comando.Parameters.AddWithValue("@estado", estado);











                var resultado = comando.ExecuteNonQuery();
                
                      if(resultado > 0)
                    {
                    MessageBox.Show("registro salvo com sucesso");
                    } 

                } catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                }



        }
    }




}
