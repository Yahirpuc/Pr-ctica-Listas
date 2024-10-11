using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
> ⚠️ **Warning:** This is a warning message!


namespace PracticasWinForms
{
    public class Form1 : Form
    {
        private LinkedList<Producto> productos;   // Práctica 1: Productos disponibles y retirados
        private List<int> numeros;                // Práctica 2: Pares e Impares
        private List<Alumno> alumnos;             // Práctica 3: Aprobados y Reprobados
        private LinkedList<Producto> productosCirculares; // Práctica 4: Eliminar y ordenar productos
        private Random random;

        private GroupBox groupBoxPractica1;
        private GroupBox groupBoxPractica2;
        private GroupBox groupBoxPractica3;
        private GroupBox groupBoxPractica4;

        private int productosRetirados = 0;
        private int productoId = 1;

        public Form1()
        {
            InitializeData();
            ConfigureForm();
        }

        private void InitializeData()
        {
            productos = new LinkedList<Producto>();
            numeros = new List<int>();
            alumnos = new List<Alumno>();
            productosCirculares = new LinkedList<Producto>();
            random = new Random();
        }

        private void ConfigureForm()
        {
            this.Text = "Prácticas de Estructuras de Datos";
            this.Size = new Size(900, 700);
            this.BackColor = Color.FromArgb(240, 248, 255);

            MenuStrip menuStrip = new MenuStrip();
            ToolStripMenuItem menuPracticas = new ToolStripMenuItem("Prácticas");

            menuPracticas.DropDownItems.Add("Práctica 1: Productos", null, (s, e) => ShowPractice(1));
            menuPracticas.DropDownItems.Add("Práctica 2: Pares e Impares", null, (s, e) => ShowPractice(2));
            menuPracticas.DropDownItems.Add("Práctica 3: Aprobados y Reprobados", null, (s, e) => ShowPractice(3));
            menuPracticas.DropDownItems.Add("Práctica 4: Eliminar y Ordenar Productos", null, (s, e) => ShowPractice(4));

            menuStrip.Items.Add(menuPracticas);
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);

            CreatePractice1Controls();
            CreatePractice2Controls();
            CreatePractice3Controls();
            CreatePractice4Controls();

            ShowPractice(1);
        }

        private void ShowPractice(int practiceNumber)
        {
            groupBoxPractica1.Visible = false;
            groupBoxPractica2.Visible = false;
            groupBoxPractica3.Visible = false;
            groupBoxPractica4.Visible = false;

            switch (practiceNumber)
            {
                case 1:
                    groupBoxPractica1.Visible = true;
                    break;
                case 2:
                    groupBoxPractica2.Visible = true;
                    break;
                case 3:
                    groupBoxPractica3.Visible = true;
                    break;
                case 4:
                    groupBoxPractica4.Visible = true;
                    break;
            }
        }

        private void ApplyButtonStyles(Button button)
        {
            button.BackColor = Color.FromArgb(135, 206, 250);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 1;
            button.ForeColor = Color.DarkBlue;
            button.Font = new Font("Arial", 10, FontStyle.Bold);
        }

        // Práctica 1: Productos disponibles y retirados
        private void CreatePractice1Controls()
        {
            groupBoxPractica1 = new GroupBox
            {
                Text = "Práctica 1: Productos disponibles y retirados",
                Size = new Size(700, 500),
                Location = new Point(50, 50),
                BackColor = Color.FromArgb(250, 235, 215),
                Visible = true
            };

            Label lblAgregar = new Label { Text = "Agregar Producto:", Location = new Point(20, 30), AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold), ForeColor = Color.DarkBlue };
            Button btnAgregar = new Button { Text = "Agregar Producto", Location = new Point(200, 30), Size = new Size(150, 40) };
            ApplyButtonStyles(btnAgregar);

            Label lblProductos = new Label { Text = "Productos Disponibles", Location = new Point(20, 80), AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold), ForeColor = Color.DarkGreen };
            ListBox lstProductos = new ListBox { Location = new Point(20, 110), Size = new Size(300, 200), BackColor = Color.Lavender };

            Button btnRetirar = new Button { Text = "Retirar Producto Seleccionado", Location = new Point(350, 110), Size = new Size(200, 40) };
            ApplyButtonStyles(btnRetirar);

            Label lblTotalProductos = new Label { Text = "Total de Productos Disponibles: 0", Location = new Point(20, 340), AutoSize = true, Font = new Font("Arial", 12, FontStyle.Italic), ForeColor = Color.DarkRed };
            Label lblProductosRetirados = new Label { Text = "Total de Productos Retirados: 0", Location = new Point(20, 370), AutoSize = true, Font = new Font("Arial", 12, FontStyle.Italic), ForeColor = Color.DarkRed };

            btnAgregar.Click += (s, e) =>
            {
                string nombre = "Producto" + productoId++;
                int cantidad = random.Next(1, 100);
                int precio = random.Next(10, 500);
                Producto nuevoProducto = new Producto(nombre, cantidad, precio);
                productos.AddLast(nuevoProducto);
                RefreshProductsList(lstProductos, lblTotalProductos);
            };

            btnRetirar.Click += (s, e) =>
            {
                if (lstProductos.SelectedItem != null)
                {
                    Producto productoSeleccionado = (Producto)lstProductos.SelectedItem;
                    productos.Remove(productoSeleccionado);
                    productosRetirados++;
                    lblProductosRetirados.Text = $"Total de Productos Retirados: {productosRetirados}";
                    RefreshProductsList(lstProductos, lblTotalProductos);
                }
            };

            groupBoxPractica1.Controls.Add(lblAgregar);
            groupBoxPractica1.Controls.Add(btnAgregar);
            groupBoxPractica1.Controls.Add(lblProductos);
            groupBoxPractica1.Controls.Add(lstProductos);
            groupBoxPractica1.Controls.Add(btnRetirar);
            groupBoxPractica1.Controls.Add(lblTotalProductos);
            groupBoxPractica1.Controls.Add(lblProductosRetirados);
            this.Controls.Add(groupBoxPractica1);
        }

        private void RefreshProductsList(ListBox listBox, Label lblTotalProductos)
        {
            listBox.DataSource = null;
            listBox.DataSource = new List<Producto>(productos);
            lblTotalProductos.Text = $"Total de Productos Disponibles: {productos.Count}";
        }

        // Práctica 2: Pares e Impares
        private void CreatePractice2Controls()
        {
            groupBoxPractica2 = new GroupBox
            {
                Text = "Práctica 2: Pares e Impares",
                Size = new Size(700, 500),
                Location = new Point(50, 50),
                BackColor = Color.FromArgb(224, 255, 255),
                Visible = false
            };

            Label lblGenerar = new Label { Text = "Generar lista de números aleatorios", Location = new Point(20, 30), AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold), ForeColor = Color.DarkBlue };
            Button btnGenerar = new Button { Text = "Generar Números", Location = new Point(300, 25), Size = new Size(150, 40) };
            ApplyButtonStyles(btnGenerar);

            Label lblPares = new Label { Text = "Números Pares", Location = new Point(20, 80), AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold), ForeColor = Color.DarkGreen };
            ListBox lstPares = new ListBox { Location = new Point(20, 100), Size = new Size(300, 200), BackColor = Color.Lavender };

            Label lblImpares = new Label { Text = "Números Impares", Location = new Point(350, 80), AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold), ForeColor = Color.DarkGreen };
            ListBox lstImpares = new ListBox { Location = new Point(350, 100), Size = new Size(300, 200), BackColor = Color.Lavender };

            btnGenerar.Click += (s, e) =>
            {
                numeros.Clear();
                for (int i = 0; i < 20; i++) numeros.Add(random.Next(1, 100));

                var pares = numeros.Where(n => n % 2 == 0).ToList();
                var impares = numeros.Where(n => n % 2 != 0).ToList();

                lstPares.DataSource = pares;
                lstImpares.DataSource = impares;
            };

            groupBoxPractica2.Controls.Add(lblGenerar);
            groupBoxPractica2.Controls.Add(btnGenerar);
            groupBoxPractica2.Controls.Add(lblPares);
            groupBoxPractica2.Controls.Add(lstPares);
            groupBoxPractica2.Controls.Add(lblImpares);
            groupBoxPractica2.Controls.Add(lstImpares);
            this.Controls.Add(groupBoxPractica2);
        }

        // Práctica 3: Aprobados y Reprobados
        private void CreatePractice3Controls()
        {
            groupBoxPractica3 = new GroupBox
            {
                Text = "Práctica 3: Aprobados y Reprobados",
                Size = new Size(700, 500),
                Location = new Point(50, 50),
                BackColor = Color.FromArgb(250, 240, 230),
                Visible = false
            };

            Label lblNombre = new Label { Text = "Nombre del Alumno:", Location = new Point(20, 30), AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold), ForeColor = Color.DarkBlue };
            TextBox txtNombre = new TextBox { Location = new Point(200, 30), Width = 200 };

            Label lblCalificacion = new Label { Text = "Calificación:", Location = new Point(20, 70), AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold), ForeColor = Color.DarkBlue };
            TextBox txtCalificacion = new TextBox { Location = new Point(200, 70), Width = 200 };

            Button btnAgregarAlumno = new Button { Text = "Agregar Alumno", Location = new Point(420, 50), Size = new Size(150, 40) };
            ApplyButtonStyles(btnAgregarAlumno);

            Label lblAprobados = new Label { Text = "Aprobados", Location = new Point(20, 120), AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold), ForeColor = Color.DarkGreen };
            ListBox lstAprobados = new ListBox { Location = new Point(20, 140), Size = new Size(300, 200), BackColor = Color.Lavender };

            Label lblReprobados = new Label { Text = "Reprobados", Location = new Point(350, 120), AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold), ForeColor = Color.DarkRed };
            ListBox lstReprobados = new ListBox { Location = new Point(350, 140), Size = new Size(300, 200), BackColor = Color.Lavender };

            btnAgregarAlumno.Click += (s, e) =>
            {
                string nombre = txtNombre.Text.Trim();
                if (int.TryParse(txtCalificacion.Text, out int calificacion) && !string.IsNullOrEmpty(nombre))
                {
                    Alumno nuevoAlumno = new Alumno(nombre, calificacion);
                    alumnos.Add(nuevoAlumno);
                    txtNombre.Clear();
                    txtCalificacion.Clear();

                    lstAprobados.DataSource = alumnos.Where(a => a.Calificacion >= 7).ToList();
                    lstReprobados.DataSource = alumnos.Where(a => a.Calificacion < 7).ToList();
                }
            };

            groupBoxPractica3.Controls.Add(lblNombre);
            groupBoxPractica3.Controls.Add(txtNombre);
            groupBoxPractica3.Controls.Add(lblCalificacion);
            groupBoxPractica3.Controls.Add(txtCalificacion);
            groupBoxPractica3.Controls.Add(btnAgregarAlumno);
            groupBoxPractica3.Controls.Add(lblAprobados);
            groupBoxPractica3.Controls.Add(lstAprobados);
            groupBoxPractica3.Controls.Add(lblReprobados);
            groupBoxPractica3.Controls.Add(lstReprobados);
            this.Controls.Add(groupBoxPractica3);
        }

        // Práctica 4: Eliminar y Ordenar Productos
        private void CreatePractice4Controls()
        {
            groupBoxPractica4 = new GroupBox
            {
                Text = "Práctica 4: Eliminar y Ordenar Productos",
                Size = new Size(700, 500),
                Location = new Point(50, 50),
                BackColor = Color.FromArgb(240, 255, 240),
                Visible = false
            };

            Label lblNombre = new Label { Text = "Nombre del Producto:", Location = new Point(20, 30), AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold), ForeColor = Color.DarkBlue };
            TextBox txtProducto = new TextBox { Location = new Point(200, 30), Width = 200 };

            Button btnAgregarProducto = new Button { Text = "Agregar Producto", Location = new Point(420, 30), Size = new Size(150, 40) };
            ApplyButtonStyles(btnAgregarProducto);

            Label lblEliminar = new Label { Text = "Eliminar Producto:", Location = new Point(20, 80), AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold), ForeColor = Color.DarkRed };
            TextBox txtEliminarProducto = new TextBox { Location = new Point(200, 80), Width = 200 };
            Button btnEliminarProducto = new Button { Text = "Eliminar Producto", Location = new Point(420, 80), Size = new Size(150, 40) };
            ApplyButtonStyles(btnEliminarProducto);

            Label lblProductos = new Label { Text = "Lista de Productos", Location = new Point(20, 130), AutoSize = true, Font = new Font("Arial", 12, FontStyle.Bold), ForeColor = Color.DarkGreen };
            ListBox lstProductos = new ListBox { Location = new Point(20, 150), Size = new Size(550, 200), BackColor = Color.Lavender };

            Label lblTotal = new Label { Text = "Costo Total: $0", Location = new Point(20, 370), AutoSize = true, Font = new Font("Arial", 12, FontStyle.Italic), ForeColor = Color.DarkRed };

            btnAgregarProducto.Click += (s, e) =>
            {
                if (!string.IsNullOrEmpty(txtProducto.Text))
                {
                    Producto nuevoProducto = new Producto(txtProducto.Text, 1, random.Next(10, 100));
                    productosCirculares.AddLast(nuevoProducto);
                    txtProducto.Clear();
                    UpdateProductList(lstProductos, lblTotal);
                }
            };

            btnEliminarProducto.Click += (s, e) =>
            {
                string clave = txtEliminarProducto.Text.Trim();
                var productoEliminar = productosCirculares.FirstOrDefault(p => p.Nombre.Equals(clave, StringComparison.OrdinalIgnoreCase));
                if (productoEliminar != null)
                {
                    productosCirculares.Remove(productoEliminar);
                    txtEliminarProducto.Clear();
                    UpdateProductList(lstProductos, lblTotal);
                }
                else
                {
                    MessageBox.Show($"El producto con nombre '{clave}' no se encontró.", "Producto No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            groupBoxPractica4.Controls.Add(lblNombre);
            groupBoxPractica4.Controls.Add(txtProducto);
            groupBoxPractica4.Controls.Add(btnAgregarProducto);
            groupBoxPractica4.Controls.Add(lblEliminar);
            groupBoxPractica4.Controls.Add(txtEliminarProducto);
            groupBoxPractica4.Controls.Add(btnEliminarProducto);
            groupBoxPractica4.Controls.Add(lblProductos);
            groupBoxPractica4.Controls.Add(lstProductos);
            groupBoxPractica4.Controls.Add(lblTotal);
            this.Controls.Add(groupBoxPractica4);
        }

        private void UpdateProductList(ListBox listBox, Label lblTotal)
        {
            listBox.DataSource = null;
            listBox.DataSource = productosCirculares.OrderBy(p => p.Nombre).ToList();
            lblTotal.Text = $"Costo Total: ${productosCirculares.Sum(p => p.Precio)}";
        }

        private class Producto
        {
            public string Nombre { get; set; }
            public int Cantidad { get; set; }
            public int Precio { get; set; }

            public Producto(string nombre, int cantidad, int precio)
            {
                Nombre = nombre;
                Cantidad = cantidad;
                Precio = precio;
            }

            public override string ToString()
            {
                return $"{Nombre} - Cantidad: {Cantidad}, Precio: ${Precio}";
            }
        }

        private class Alumno
        {
            public string Nombre { get; set; }
            public int Calificacion { get; set; }

            public Alumno(string nombre, int calificacion)
            {
                Nombre = nombre;
                Calificacion = calificacion;
            }

            public override string ToString()
            {
                return $"{Nombre} - Calificación: {Calificacion}";
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
