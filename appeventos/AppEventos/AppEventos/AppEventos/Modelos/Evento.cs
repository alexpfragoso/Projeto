using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppEventos.Modelos
{
    [Table("Evento")]
    public class Evento
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set;}
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Local { get; set; }
        public string Data { get; set; }
        public string Horario { get; set; }
        public string Organizador { get; set; }
        public string Valor { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        public string Imagem { get; set; }
    }
}
