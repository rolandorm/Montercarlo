namespace Montercarlo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("") || textBox4.Text.Equals("") || textBox5.Text.Equals(""))
            {
                MessageBox.Show("Los números tienen que ser MAYOR que cero, NO VACÍOS");
                return;
            }

            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("") || textBox4.Text.Equals("") || textBox5.Text.Equals(""))
            {
                MessageBox.Show("Los números tienen que ser MAYOR que cero, NO VACÍOS");
                return;
            }

            int NoPan = Convert.ToInt32(textBox1.Text);
            int MinPan = Convert.ToInt32(textBox2.Text);
            int MinVida = Convert.ToInt32(textBox3.Text);
            int MaxVida = Convert.ToInt32(textBox4.Text);
            int NoSim = Convert.ToInt32(textBox5.Text);

            if ( NoPan <= 0 || MinPan <= 0 || MinVida <= 0 || MaxVida <= 0 || NoSim <= 0)
            {
                MessageBox.Show("Los números tienen que ser enteros MAYORES que cero");
                return;
            }

            if (NoPan <= MinPan || MinVida >= MaxVida)
            {
                MessageBox.Show("Revisa los limites de Paneles y Vida");
                return;
            }

            ClassMT montecarlo = new ClassMT();
            List<List<int>> listaSalida = montecarlo.SimSatelite(MinPan,NoPan,MinVida,MaxVida,NoSim);

            llenarGrid(listaSalida,NoPan);
        }

        private void llenarGrid(List<List<int>> listaDeListas, int numPan)
        {
            // Limpiar el DataGridView antes de llenarlo
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // Establecer un número de columnas dinámico basado en el número de listas
            int numeroDeColumnas = listaDeListas.Count;

            dataGridView1.Columns.Add("# Simulacion", "# Simulacion");

            for (int i = 0; i < numPan; i++)
            {
                dataGridView1.Columns.Add("Panel " + (i + 1), "Panel " + (i + 1));
            }

            dataGridView1.Columns.Add("Resultado", "Resultado");

            // Determinar el número máximo de filas basado en la lista más larga
            int numeroDeFilas = listaDeListas.Max(l => l.Count);

            // Añadir filas al DataGridView de forma transpuesta
            for (int i = 0; i < numeroDeFilas; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);

                // Rellenar cada fila con los valores correspondientes
                for (int j = 0; j < numeroDeColumnas; j++)
                {
                    if (i < listaDeListas[j].Count) // Verifica si hay un valor en la posición actual
                    {
                        row.Cells[j].Value = listaDeListas[j][i];
                    }
                    else
                    {
                        row.Cells[j].Value = ""; // Dejar la celda vacía si no hay más elementos
                    }
                }
                dataGridView1.Rows.Add(row);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
