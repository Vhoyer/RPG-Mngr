using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgMngr.Dnd_35
{
    public static class playersDefaultTables
    {
        public static DataTable periaciaTable()
        {
            DataTable periciaTable = new DataTable();
            periciaTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Perícias de classe", typeof(bool)),
                new DataColumn("Nome da perícia", typeof(string)),
                new DataColumn("Hab. chave", typeof(string)),
                new DataColumn("Mod. de perícia", typeof(int)),
                new DataColumn("Mod. de habilidade", typeof(int)),
                new DataColumn("Grad.", typeof(int)),
                new DataColumn("Outros mod.", typeof(int))
            });

            periciaTable.Rows.Add(false, "Abrir fechadura", "DES", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Acrobacia •", "DES*", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Adestrar animais", "CAR", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Arte da fuga •", "DES*", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Atuação • ()", "CAR", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Atuação • ()", "CAR", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Atuação • ()", "CAR", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Avaliação •", "INT", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Blefar •", "CAR", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Cavalgar •", "DES", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Concentração •", "CON", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Conhecimento ()", "INT", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Conhecimento ()", "INT", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Conhecimento ()", "INT", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Conhecimento ()", "INT", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Conhecimento ()", "INT", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Cura •", "SAB", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Decifrar Escrita", "INT", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Diplomacia •", "CAR", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Equilíbrio •", "DES*", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Escalar •", "FOR*", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Esconder-se •", "DES*", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Falsificação •", "INT", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Furtividade •", "DES*", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Identificar Magias", "INT", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Intimidação •", "CAR", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Natação •", "FOR*", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Observar •", "SAB", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Obter Informação •", "CON", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Ofícios • ()", "INT", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Ofícios • ()", "INT", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Ofícios • ()", "INT", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Operar Mecanismo •", "INT", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Ouvir •", "SAB", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Prestidigitação", "DES*", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Procurar •", "INT", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Profissão ()", "SAB", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Profissão ()", "SAB", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Saltar •", "FOR*", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Sentir Motivação •", "SAB", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Sobrevivencia •", "SAB", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Usar Cordas •", "DES", 0, 0, 0, 0);
            periciaTable.Rows.Add(false, "Usar Instrumento Mágico", "CAR", 0, 0, 0, 0);

            return periciaTable;
        }

        public static DataTable equipamentoTable()
        {
            DataTable periciaTable = new DataTable();
            periciaTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Item", typeof(bool)),
                new DataColumn("Localização", typeof(string)),
                new DataColumn("Pag. ref.", typeof(int)),
                new DataColumn("Peso (Kg)", typeof(float))
            });

            return periciaTable;
        }
    }
}
