using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseFiller
{
    /// <summary>
    /// Просто форма ожидания, всплывающая при длительных операциях
    /// </summary>
    public partial class FWait : Form
    {
        public Action Worker { get; set; }
        /// <summary>
        /// Просто форма ожидания, всплывающая при длительных операциях. Принимает метод, который долго выполняется.
        /// По закрытию потока с длительной операцией, форма закроется.
        /// </summary>
        /// <param name="worker">Долго выполняемый метод</param>
        public FWait(Action worker)
        {
            InitializeComponent();
            if(worker == null)
                throw new ArgumentNullException();
            Worker = worker;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(Worker).ContinueWith(t => { Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }

   
    }
}
