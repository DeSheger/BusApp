using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using BusApp1.Models;

namespace BusApp1
{
    public partial class TicketListForm : MaterialForm
    {
        public List<Ticket> submittedTickets;

        public TicketListForm(List<Ticket> tickets)
        {
            InitializeComponent();
            submittedTickets = tickets;
        }


        public TicketListForm()
        {
            InitializeComponent();
        }

        private void TicketListForm_Load(object sender, EventArgs e)
        {
            dataGridViewTickets.DataSource = new BindingList<Ticket>(submittedTickets);
        }
    }
}
