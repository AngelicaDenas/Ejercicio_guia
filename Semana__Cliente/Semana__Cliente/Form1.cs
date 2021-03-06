using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //Declaramos objeto de la clase socket que es gloval
        Socket server;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {


        }
        //Al clicar el boton enviar, lo hemos cambiado por conectar, ya cuando he escrito un nombre y alguna opcion marcada
        private void button1_Click(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            IPAddress direc = IPAddress.Parse("192.168.56.102");
            IPEndPoint ipep = new IPEndPoint(direc, 9050);

            //Creamos el socket 
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipep);//Intentamos conectar el socket
                this.BackColor = Color.Green;
                MessageBox.Show("Conectado");
            }
               // por si no podemos conectarnos al servidor 
            catch (SocketException ex)
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("No he podido conectar con el servidor");
                return;
            }
      

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            //Mensaje de desconexión lo hacemos con 0/ de esta manera el servidor no se cierra
            string mensaje = "0/";

            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);

            // Nos desconectamos
            this.BackColor = Color.Gray;
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (Longitud.Checked)
            {
                string mensaje = "1/" + nombre.Text;
                // Enviamos al servidor el nombre tecleado, aqui lo convierte en un vector de bits y 
                // esto es lo que envia al servidor 
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor, ponemos un splid para que lo parta por el final de string 
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                MessageBox.Show("La longitud de tu nombre es: " + mensaje);
            }
            //hacemos lo mismo para la respuesta numero 2 
            else if (Bonito.Checked)
            {
                string mensaje = "2/" + nombre.Text;
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                //Recibimos la respuesta del servidor
                byte[] msg2 = new byte[80];
                server.Receive(msg2);
                mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];


                if (mensaje == "SI")
                    MessageBox.Show("Tu nombre ES bonito.");
                else
                    MessageBox.Show("Tu nombre NO bonito. Lo siento.");

            }


        }

      
        
            
        }
    }


