using System;
using System.Collections.Generic;
using System.Text;
using AppEventos.Modelos;
using SQLite;
using Xamarin.Forms;
using System.Linq;

namespace AppEventos.DataBase
{
    class Database
    {

        private SQLiteConnection Conexao;

        public Database() {

            var dep = DependencyService.Get<IPath>();
            string path = dep.GetPath("database.sqlite");

            Conexao = new SQLiteConnection(path);
            Conexao.CreateTable<Evento>();
        }

        public List<Evento> ListarEventos() {

            return Conexao.Table<Evento>().ToList();
        }

        public Evento ConsultarEventoPorID(int id){

            return Conexao.Table<Evento>().Where(a=>a.Id == id).FirstOrDefault();
        }

        public List<Evento> Pesquisar(string palavra) {
            return Conexao.Table<Evento>().Where(a => a.Nome.Contains(palavra)).ToList();
        }

        public void CadastrarEvento(Evento evento) {

            Conexao.Insert(evento);
        }

        public void AlterarEvento(Evento evento) {

            Conexao.Update(evento);
        }

        public void ExcluirEvento(Evento evento) {

            Conexao.Delete(evento);
        }
    }
}
