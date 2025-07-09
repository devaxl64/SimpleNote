using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNoteClass
{
    internal class Color
    {
        public int Id { get; set; }
        public int TypeColor { get; set; }
        public int Weight { get; set; }
        public bool Active { get; set; }
        public Color()
        {
        }
        public Color(int id, int typeColor, int weight, bool active)
        {
            Id = id;
            TypeColor = typeColor;
            Weight = weight;
            Active = active;
        }
        public Color(int typeColor, int weight, bool active)
        {
            TypeColor = typeColor;
            Weight = weight;
            Active = active;
        }
        public Color(int typeColor, int weight)
        {
            TypeColor = typeColor;
            Weight = weight;
        }
        

    }
}
