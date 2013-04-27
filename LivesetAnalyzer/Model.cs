using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LivesetAnalyzer
{
    class Model
    {
        private static Model model;
        private bool rmChanged = false;

        private Model()
        {

        }

        public static Model getModel()
        {
            if (model == null)
            {
                model = new Model();
            }
            return model;
        }

        public bool getRmChanged()
        {
            return rmChanged;
        }

        public void setRmChanged(bool changed)
        {
            this.rmChanged = changed;
        }




    }
}
